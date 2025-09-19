using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using BibleShow.Core.Services;
using Foundation;
using Microsoft.Extensions.DependencyInjection;
using ObjCRuntime;
using UIKit;

namespace BibleShow.UI.Platforms.MacCatalyst;

/// <summary>
/// Delegate type for native exception handler
/// </summary>
public delegate void NSUncaughtExceptionHandler(NSException exception);

/// <summary>
/// MacCatalyst platform-specific application delegate that handles app lifecycle,
/// crash reporting, and system monitoring.
/// </summary>
[Register("AppDelegate")]
[SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", 
    Justification = "AppDelegate is a standard naming convention in macOS/iOS development")]
public partial class AppDelegate : MauiUIApplicationDelegate
{
    #region P/Invoke Declarations
    
    [DllImport(Constants.ObjectiveCLibrary, EntryPoint = "NSSetUncaughtExceptionHandler")]
    private static extern void NSSetUncaughtExceptionHandler(NSUncaughtExceptionHandler handler);
    
    #endregion
    
    #region Private Fields
    
    private ILoggingService? _loggingService;
    private ICrashReportingService? _crashReportingService;
    private readonly SemaphoreSlim _initializationSemaphore = new(1, 1);
    
    private NSObject? _terminationObserver;
    private NSObject? _memoryWarningObserver;
    private NSObject? _backgroundTransitionObserver;
    
    private bool _disposed;
    
    #endregion
    
    #region Constructor
    
    public AppDelegate()
    {
        SetupGlobalExceptionHandlers();
    }
    
    #endregion
    
    #region MauiUIApplicationDelegate Overrides
    
    protected override MauiApp CreateMauiApp()
    {
        try
        {
            _initializationSemaphore.Wait();
            
            var app = MainThread.IsMainThread 
                ? CreateMauiAppInternal() 
                : InvokeOnMainThread(CreateMauiAppInternal);
            
            // Initialize services from the DI container
            _loggingService = app.Services.GetRequiredService<ILoggingService>();
            _crashReportingService = app.Services.GetRequiredService<ICrashReportingService>();
            
            ValidateServices(app.Services);
            SetupPlatformMonitoring();
            SetupNativeExceptionHandler();
            
            _loggingService.LogInformation("MAUI application created and configured successfully");
            return app;
        }
        catch (Exception ex)
        {
            HandleAppCreationError(ex);
            throw;
        }
        finally
        {
            _initializationSemaphore.Release();
        }
    }
    
    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        try
        {
            var result = base.FinishedLaunching(application, launchOptions);
            
            if (_crashReportingService != null && _loggingService != null)
            {
                var startupMetrics = CollectStartupMetrics();
                _crashReportingService.LogEvent("app_launch_completed", startupMetrics);
                _loggingService.LogInformation("Application launch completed successfully");
            }
            
            return result;
        }
        catch (Exception ex)
        {
            _loggingService?.LogCritical("Critical error during application launch", ex);
            _crashReportingService?.ReportCrash(ex, new Dictionary<string, string>
            {
                { "phase", "launch" },
                { "platform", "maccatalyst" }
            });
            throw;
        }
    }
    
    #endregion
    
    #region Exception Handling Setup
    
    private void SetupGlobalExceptionHandlers()
    {
        AppDomain.CurrentDomain.UnhandledException += OnAppDomainUnhandledException;
        TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
    }
    
    private void SetupNativeExceptionHandler()
    {
        try
        {
            NSSetUncaughtExceptionHandler(OnNativeException);
            _loggingService?.LogInformation("Native exception handler configured");
        }
        catch (ExternalException ex)
        {
            _loggingService?.LogError("Failed to setup native exception handler", ex);
            _crashReportingService?.ReportError("Native exception handler setup failed", ex);
        }
        catch (InvalidOperationException ex)
        {
            _loggingService?.LogError("Failed to setup native exception handler", ex);
            _crashReportingService?.ReportError("Native exception handler setup failed", ex);
        }
    }
    
    #endregion
    
    #region Platform Monitoring Setup
    
    private void SetupPlatformMonitoring()
    {
        try
        {
            SetupTerminationObserver();
            SetupMemoryWarningObserver();
            SetupBackgroundTransitionObserver();
            
            _loggingService?.LogInformation("Platform monitoring configured successfully");
        }
        catch (InvalidOperationException ex)
        {
            _loggingService?.LogError("Failed to setup platform monitoring", ex);
            _crashReportingService?.ReportError("Platform monitoring setup failed", ex);
        }
        catch (ExternalException ex)
        {
            _loggingService?.LogError("Failed to setup platform monitoring", ex);
            _crashReportingService?.ReportError("Platform monitoring setup failed", ex);
        }
    }
    
    private void SetupTerminationObserver()
    {
        _terminationObserver = NSNotificationCenter.DefaultCenter.AddObserver(
            UIApplication.WillTerminateNotification,
            OnAppTermination);
    }
    
    private void SetupMemoryWarningObserver()
    {
        _memoryWarningObserver = NSNotificationCenter.DefaultCenter.AddObserver(
            UIApplication.DidReceiveMemoryWarningNotification,
            OnMemoryWarning);
    }
    
    private void SetupBackgroundTransitionObserver()
    {
        _backgroundTransitionObserver = NSNotificationCenter.DefaultCenter.AddObserver(
            UIApplication.DidEnterBackgroundNotification,
            OnBackgroundTransition);
    }
    
    #endregion
    
    #region Event Handlers
    
    private void OnAppDomainUnhandledException(object? sender, UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is Exception ex)
        {
            var metadata = new Dictionary<string, string>
            {
                { "handler", "appdomain_unhandled" },
                { "is_terminating", e.IsTerminating.ToString() },
                { "platform", "maccatalyst" },
                { "architecture", RuntimeInformation.ProcessArchitecture.ToString() }
            };
            
            try
            {
                _crashReportingService?.ReportCrash(ex, metadata);
            }
            catch (InvalidOperationException reportingEx)
            {
                WriteFallbackLog(ex, "AppDomain unhandled exception", reportingEx);
            }
            catch (IOException reportingEx)
            {
                WriteFallbackLog(ex, "AppDomain unhandled exception", reportingEx);
            }
        }
    }
    
    private void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        var metadata = new Dictionary<string, string>
        {
            { "handler", "task_unobserved" },
            { "platform", "maccatalyst" },
            { "architecture", RuntimeInformation.ProcessArchitecture.ToString() }
        };
        
        try
        {
            _crashReportingService?.ReportCrash(e.Exception, metadata);
            e.SetObserved(); // Prevent process termination
        }
        catch (InvalidOperationException reportingEx)
        {
            WriteFallbackLog(e.Exception, "Unobserved task exception", reportingEx);
            e.SetObserved(); // Still prevent termination
        }
        catch (IOException reportingEx)
        {
            WriteFallbackLog(e.Exception, "Unobserved task exception", reportingEx);
            e.SetObserved(); // Still prevent termination
        }
    }
    
    private void OnNativeException(NSException exception)
    {
        var metadata = new Dictionary<string, string>
        {
            { "handler", "native_exception" },
            { "platform", "maccatalyst" },
            { "native_name", exception.Name ?? "unknown" },
            { "native_reason", exception.Reason ?? "unknown" }
        };
        
        var managedException = new InvalidOperationException(
            $"Native exception: {exception.Name} - {exception.Reason}");
        
        try
        {
            _crashReportingService?.ReportCrash(managedException, metadata);
        }
        catch (InvalidOperationException reportingEx)
        {
            WriteFallbackLog(managedException, "Native exception", reportingEx);
        }
        catch (IOException reportingEx)
        {
            WriteFallbackLog(managedException, "Native exception", reportingEx);
        }
    }
    
    private void OnAppTermination(NSNotification notification)
    {
        var metadata = CollectSystemMetadata();
        metadata["termination_reason"] = "app_termination";
        
        try
        {
            _crashReportingService?.LogEvent("app_termination", metadata);
        }
        catch (InvalidOperationException ex)
        {
            _loggingService?.LogError("Failed to log app termination event", ex);
        }
        catch (IOException ex)
        {
            _loggingService?.LogError("Failed to log app termination event", ex);
        }
    }
    
    private void OnMemoryWarning(NSNotification notification)
    {
        var metadata = CollectSystemMetadata();
        metadata["event_type"] = "memory_warning";
        metadata["memory_usage"] = GetMemoryUsage().ToString(CultureInfo.InvariantCulture);
        
        try
        {
            _crashReportingService?.LogEvent("memory_warning", metadata);
            
            // Trigger garbage collection
            Task.Run(() =>
            {
                try
                {
                    GC.Collect(2, GCCollectionMode.Aggressive, true, true);
                    _loggingService?.LogInformation("Memory cleanup completed after warning");
                }
                catch (OutOfMemoryException ex)
                {
                    _loggingService?.LogError("Memory cleanup failed", ex);
                }
                catch (InvalidOperationException ex)
                {
                    _loggingService?.LogError("Memory cleanup failed", ex);
                }
            });
        }
        catch (InvalidOperationException ex)
        {
            _loggingService?.LogError("Failed to handle memory warning", ex);
        }
        catch (IOException ex)
        {
            _loggingService?.LogError("Failed to handle memory warning", ex);
        }
    }
    
    private void OnBackgroundTransition(NSNotification notification)
    {
        var metadata = CollectSystemMetadata();
        metadata["event_type"] = "background_transition";
        
        try
        {
            _crashReportingService?.LogEvent("background_transition", metadata);
        }
        catch (InvalidOperationException ex)
        {
            _loggingService?.LogError("Failed to log background transition", ex);
        }
        catch (IOException ex)
        {
            _loggingService?.LogError("Failed to log background transition", ex);
        }
    }
    
    #endregion
    
    #region Helper Methods
    
    private static MauiApp CreateMauiAppInternal()
    {
        return MauiProgram.CreateMauiApp();
    }
    
    private static T InvokeOnMainThread<T>(Func<T> action)
    {
        var tcs = new TaskCompletionSource<T>();
        
        MainThread.BeginInvokeOnMainThread(() =>
        {
            try
            {
                var result = action();
                tcs.SetResult(result);
            }
            catch (InvalidOperationException ex)
            {
                tcs.SetException(ex);
            }
            catch (IOException ex)
            {
                tcs.SetException(ex);
            }
        });
        
        return tcs.Task.GetAwaiter().GetResult();
    }
    
    private static void ValidateServices(IServiceProvider services)
    {
        var requiredServices = new[] { typeof(ILoggingService), typeof(ICrashReportingService) };
        
        foreach (var serviceType in requiredServices)
        {
            if (services.GetService(serviceType) == null)
            {
                throw new InvalidOperationException($"Required service {serviceType.Name} is not registered");
            }
        }
    }
    
    private Dictionary<string, string> CollectSystemMetadata()
    {
        var metadata = new Dictionary<string, string>
        {
            { "platform", "maccatalyst" },
            { "architecture", RuntimeInformation.ProcessArchitecture.ToString() },
            { "os_version", UIDevice.CurrentDevice?.SystemVersion ?? "unknown" },
            { "device_name", UIDevice.CurrentDevice?.Name ?? "unknown" },
            { "device_model", UIDevice.CurrentDevice?.Model ?? "unknown" }
        };
        
        try
        {
            using var processInfo = new NSProcessInfo();
            metadata["physical_memory"] = processInfo.PhysicalMemory.ToString(CultureInfo.InvariantCulture);
            metadata["processor_count"] = processInfo.ProcessorCount.ToString(CultureInfo.InvariantCulture);
            metadata["thermal_state"] = processInfo.ThermalState.ToString();
            metadata["low_power_mode"] = processInfo.LowPowerModeEnabled.ToString();
            metadata["system_uptime"] = processInfo.SystemUptime.ToString(CultureInfo.InvariantCulture);
        }
        catch (ObjectDisposedException ex)
        {
            _loggingService?.LogWarning($"Failed to collect some system metadata: {ex.Message}");
        }
        catch (ExternalException ex)
        {
            _loggingService?.LogWarning($"Failed to collect some system metadata: {ex.Message}");
        }
        
        return metadata;
    }
    
    private Dictionary<string, string> CollectStartupMetrics()
    {
        var metrics = CollectSystemMetadata();
        metrics["event_type"] = "startup_metrics";
        metrics["timestamp"] = DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture);
        
        return metrics;
    }
    
    private long GetMemoryUsage()
    {
        try
        {
            using var processInfo = new NSProcessInfo();
            return (long)processInfo.PhysicalMemory;
        }
        catch (ObjectDisposedException ex)
        {
            _loggingService?.LogWarning($"Failed to get memory usage: {ex.Message}");
            return 0;
        }
        catch (ExternalException ex)
        {
            _loggingService?.LogWarning($"Failed to get memory usage: {ex.Message}");
            return 0;
        }
    }
    
    private void HandleAppCreationError(Exception ex)
    {
        var errorType = ex switch
        {
            InvalidOperationException => "service_configuration",
            IOException => "io_operations",
            System.Security.SecurityException => "security",
            TypeLoadException => "assembly_loading",
            ExternalException => "platform_interface",
            _ => "unexpected"
        };
        
        _loggingService?.LogCritical($"MAUI app creation failed: {errorType}", ex);
        
        var metadata = CollectSystemMetadata();
        metadata["error_type"] = errorType;
        metadata["creation_phase"] = "maui_app_creation";
        
        try
        {
            _crashReportingService?.ReportError("App creation error", ex, metadata);
        }
        catch (InvalidOperationException reportingEx)
        {
            WriteFallbackLog(ex, "App creation error", reportingEx);
        }
        catch (IOException reportingEx)
        {
            WriteFallbackLog(ex, "App creation error", reportingEx);
        }
    }
    
    private static void WriteFallbackLog(Exception originalException, string context, Exception? reportingException = null)
    {
        try
        {
            var logPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "BibleShow_Crash.log");
            
            var logEntry = $"[{DateTime.UtcNow:O}] {context}\n" +
                          $"Original Exception: {originalException}\n";
            
            if (reportingException != null)
            {
                logEntry += $"Reporting Exception: {reportingException}\n";
            }
            
            logEntry += "\n" + new string('-', 80) + "\n\n";
            
            File.AppendAllText(logPath, logEntry);
        }
        catch (IOException)
        {
            // If we can't write to file, write to console as last resort
            Console.WriteLine($"FALLBACK LOG - {context}: {originalException.Message}");
            if (reportingException != null)
            {
                Console.WriteLine($"Reporting error: {reportingException.Message}");
            }
        }
        catch (UnauthorizedAccessException)
        {
            // If we can't write to file, write to console as last resort
            Console.WriteLine($"FALLBACK LOG - {context}: {originalException.Message}");
            if (reportingException != null)
            {
                Console.WriteLine($"Reporting error: {reportingException.Message}");
            }
        }
    }
    
    #endregion
    
    #region IDisposable Implementation
    
    protected override void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            try
            {
                _terminationObserver?.Dispose();
                _memoryWarningObserver?.Dispose();
                _backgroundTransitionObserver?.Dispose();
                _initializationSemaphore?.Dispose();
                
                _loggingService?.LogInformation("AppDelegate disposed successfully");
            }
            catch (ObjectDisposedException ex)
            {
                _loggingService?.LogError("Error during AppDelegate disposal", ex);
            }
            catch (InvalidOperationException ex)
            {
                _loggingService?.LogError("Error during AppDelegate disposal", ex);
            }
            finally
            {
                _disposed = true;
            }
        }
        
        base.Dispose(disposing);
    }
    
    #endregion
}