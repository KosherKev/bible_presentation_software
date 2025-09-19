using BibleShow.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibleShow.UI;

public partial class App : Application
{
    private ICrashReportingService? _crashReportingService;
    private ILoggingService? _loggingService;

    private IServiceProvider? _services;

    public App()
    {
        InitializeComponent();
        // MainPage will be set after services are initialized
    }

    public void InitializeServices(IServiceProvider services)
    {
        _services = services;
        _crashReportingService = services.GetRequiredService<ICrashReportingService>();
        _loggingService = services.GetRequiredService<ILoggingService>();

        // Initialize crash reporting
        _crashReportingService.Initialize();

        // Set up global unhandled exception handlers
        AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;

        // Set the main page to AppShell - application builds successfully
        MainPage = new AppShell();
    }

    private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is Exception exception && _crashReportingService != null)
        {
            _crashReportingService.ReportCrash(exception, new Dictionary<string, string>
            {
                { "handler", "unhandled_exception" },
                { "is_terminating", e.IsTerminating.ToString() }
            });
        }
    }

    private void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        if (e.Exception != null && _crashReportingService != null)
        {
            _crashReportingService.ReportCrash(e.Exception, new Dictionary<string, string>
            {
                { "handler", "unobserved_task_exception" }
            });
            e.SetObserved();
        }
    }

    protected override void OnStart()
    {
        if (_crashReportingService == null || _loggingService == null)
            return;
            
        try
        {
            _crashReportingService.LogEvent("app_start");
        }
        catch (InvalidOperationException ex)
        {
            _loggingService.LogError("Failed to log app start event - service not initialized", ex);
            _crashReportingService.ReportError("Failed to log app start event", ex, new Dictionary<string, string>
            {
                { "error_type", "initialization_error" }
            });
        }
        catch (ArgumentException ex)
        {
            _loggingService.LogError("Failed to log app start event - invalid event data", ex);
            _crashReportingService.ReportError("Failed to log app start event", ex, new Dictionary<string, string>
            {
                { "error_type", "invalid_data" }
            });
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _loggingService.LogError("Failed to log app start event - unexpected error", ex);
            _crashReportingService.ReportError("Failed to log app start event", ex, new Dictionary<string, string>
            {
                { "error_type", "unexpected" }
            });
        }
    }

    protected override void OnSleep()
    {
        if (_crashReportingService == null || _loggingService == null)
            return;
            
        try
        {
            _crashReportingService.LogEvent("app_sleep");
        }
        catch (InvalidOperationException ex)
        {
            _loggingService.LogError("Failed to log app sleep event - service not initialized", ex);
            _crashReportingService.ReportError("Failed to log app sleep event", ex, new Dictionary<string, string>
            {
                { "error_type", "initialization_error" }
            });
        }
        catch (ArgumentException ex)
        {
            _loggingService.LogError("Failed to log app sleep event - invalid event data", ex);
            _crashReportingService.ReportError("Failed to log app sleep event", ex, new Dictionary<string, string>
            {
                { "error_type", "invalid_data" }
            });
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _loggingService.LogError("Failed to log app sleep event - unexpected error", ex);
            _crashReportingService.ReportError("Failed to log app sleep event", ex, new Dictionary<string, string>
            {
                { "error_type", "unexpected" }
            });
        }
    }

    protected override void OnResume()
    {
        if (_crashReportingService == null || _loggingService == null)
            return;
            
        try
        {
            _crashReportingService.LogEvent("app_resume");
        }
        catch (InvalidOperationException ex)
        {
            _loggingService.LogError("Failed to log app resume event - service not initialized", ex);
            _crashReportingService.ReportError("Failed to log app resume event", ex, new Dictionary<string, string>
            {
                { "error_type", "initialization_error" }
            });
        }
        catch (ArgumentException ex)
        {
            _loggingService.LogError("Failed to log app resume event - invalid event data", ex);
            _crashReportingService.ReportError("Failed to log app resume event", ex, new Dictionary<string, string>
            {
                { "error_type", "invalid_data" }
            });
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _loggingService.LogError("Failed to log app resume event - unexpected error", ex);
            _crashReportingService.ReportError("Failed to log app resume event", ex, new Dictionary<string, string>
            {
                { "error_type", "unexpected" }
            });
        }
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Create a simple ContentPage first, then set AppShell after services are initialized
        var initialPage = new ContentPage
        {
            Title = "BibleShow",
            Content = new Label
            {
                Text = "Loading...",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }
        };

        var window = new Window(initialPage)
        {
            Title = "BibleShow"
        };

#if MACCATALYST
        // Set window properties for MacCatalyst
        window.MinimumWidth = 800;
        window.MinimumHeight = 600;
        window.Width = 1200;
        window.Height = 800;
#endif

        return window;
    }
}
