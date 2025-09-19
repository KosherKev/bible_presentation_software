using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BibleShow.Core.Services
{
    public sealed class CrashReportingService : ICrashReportingService, IDisposable
    {
        private readonly ILoggingService _loggingService;
        private readonly string _crashReportsPath;
        private readonly string _eventsPath;
        private readonly object _fileLock = new();
        private readonly SemaphoreSlim _initializationLock = new(1, 1);
        private readonly JsonSerializerOptions? _jsonOptions;
        private static readonly JsonSerializerOptions _defaultJsonOptions = new JsonSerializerOptions 
        { 
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        private bool _isInitialized;
        private bool _disposed;
        
        ~CrashReportingService()
        {
            Dispose(false);
        }

        public CrashReportingService(ILoggingService loggingService)
        {
            ArgumentNullException.ThrowIfNull(loggingService);
            _loggingService = loggingService;
            
            try
            {
                var appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BibleShow", "CrashReports");
                _crashReportsPath = Path.Combine(appDataPath, "crashes");
                _eventsPath = Path.Combine(appDataPath, "events");
                
                _jsonOptions = new JsonSerializerOptions 
                { 
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
            }
            catch (UnauthorizedAccessException ex)
            {
                // Use console as fallback since logging service might not be fully functional
                Console.WriteLine($"Access denied while initializing crash reporting paths: {ex.Message}");
                // Don't rethrow - continue with limited functionality using temp directories
                _crashReportsPath = Path.GetTempPath();
                _eventsPath = Path.GetTempPath();
            }
            catch (IOException ex)
            {
                // Use console as fallback since logging service might not be fully functional
                Console.WriteLine($"IO error while initializing crash reporting paths: {ex.Message}");
                // Don't rethrow - continue with limited functionality using temp directories
                _crashReportsPath = Path.GetTempPath();
                _eventsPath = Path.GetTempPath();
            }
            catch (SecurityException ex)
            {
                // Use console as fallback since logging service might not be fully functional
                Console.WriteLine($"Security error while initializing crash reporting paths: {ex.Message}");
                // Don't rethrow - continue with limited functionality using temp directories
                _crashReportsPath = Path.GetTempPath();
                _eventsPath = Path.GetTempPath();
            }
        }

        public async Task InitializeAsync()
        {
            ObjectDisposedException.ThrowIf(_disposed, this);

            try
            {
                await _initializationLock.WaitAsync().ConfigureAwait(false);
                
                if (_isInitialized)
                {
                    _loggingService.LogInformation("Crash reporting service already initialized");
                    return;
                }

                Directory.CreateDirectory(_crashReportsPath);
                Directory.CreateDirectory(_eventsPath);
                
                await ValidateDirectoryAccessAsync().ConfigureAwait(false);
                
                _isInitialized = true;
                _loggingService.LogInformation("Crash reporting service initialized successfully");
            }
            catch (UnauthorizedAccessException ex)
            {
                _loggingService.LogError("Access denied while initializing crash reporting service", ex);
                throw;
            }
            catch (IOException ex)
            {
                _loggingService.LogError("IO error while initializing crash reporting service", ex);
                throw;
            }
            finally
            {
                _initializationLock.Release();
            }
        }

        public void Initialize()
        {
            InitializeAsync().GetAwaiter().GetResult();
        }

        public void ReportCrash(Exception exception, IDictionary<string, string>? metadata = null)
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
            ArgumentNullException.ThrowIfNull(exception);
            if (!_isInitialized)
                throw new InvalidOperationException("Service not initialized. Call Initialize() first.");

            try
            {
                var crashReport = new CrashReport
                {
                    Timestamp = DateTime.UtcNow,
                    ExceptionType = exception.GetType().FullName ?? "Unknown",
                    Message = exception.Message,
                    StackTrace = exception.StackTrace,
                    Metadata = metadata ?? new Dictionary<string, string>(),
                    OSVersion = Environment.OSVersion.ToString(),
                    RuntimeVersion = Environment.Version.ToString(),
                    ProcessId = Environment.ProcessId,
                    MachineName = Environment.MachineName,
                    InnerException = exception.InnerException != null ? new InnerExceptionInfo
                    {
                        Type = exception.InnerException.GetType().FullName ?? "Unknown",
                        Message = exception.InnerException.Message,
                        StackTrace = exception.InnerException.StackTrace
                    } : null
                };

                SaveCrashReport(crashReport);
                _loggingService.LogCritical($"Crash reported: {exception.Message}", exception);
            }
            catch (IOException ex)
            {
                _loggingService.LogError("Failed to write crash report to disk", ex);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _loggingService.LogError("Access denied while saving crash report", ex);
                throw;
            }
            catch (JsonException ex)
            {
                _loggingService.LogError("Failed to serialize crash report", ex);
                throw;
            }
        }

        public void ReportError(string message, Exception? exception = null, IDictionary<string, string>? metadata = null)
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
            if (string.IsNullOrEmpty(message))
                throw new ArgumentException("Message cannot be null or empty", nameof(message));
            if (!_isInitialized)
                throw new InvalidOperationException("Service not initialized. Call Initialize() first.");

            try
            {
                var errorReport = new CrashReport
                {
                    Timestamp = DateTime.UtcNow,
                    ExceptionType = exception?.GetType().FullName ?? "Error",
                    Message = message,
                    StackTrace = exception?.StackTrace,
                    Metadata = metadata ?? new Dictionary<string, string>(),
                    OSVersion = Environment.OSVersion.ToString(),
                    RuntimeVersion = Environment.Version.ToString(),
                    ProcessId = Environment.ProcessId,
                    MachineName = Environment.MachineName
                };

                SaveCrashReport(errorReport);
                _loggingService.LogError(message, exception);
            }
            catch (IOException ex)
            {
                _loggingService.LogError("Failed to write error report to disk", ex);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _loggingService.LogError("Access denied while saving error report", ex);
                throw;
            }
            catch (JsonException ex)
            {
                _loggingService.LogError("Failed to serialize error report", ex);
                throw;
            }
        }

        public void LogEvent(string eventName, IDictionary<string, string>? parameters = null)
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
            if (string.IsNullOrEmpty(eventName))
                throw new ArgumentException("Event name cannot be null or empty", nameof(eventName));
            if (!_isInitialized)
                throw new InvalidOperationException("Service not initialized. Call Initialize() first.");

            try
            {
                var eventReport = new EventReport
                {
                    Timestamp = DateTime.UtcNow,
                    EventName = eventName,
                    Parameters = parameters ?? new Dictionary<string, string>(),
                    ProcessId = Environment.ProcessId,
                    MachineName = Environment.MachineName
                };

                SaveEventReport(eventReport);
                _loggingService.LogInformation($"Event logged: {eventName}");
            }
            catch (IOException ex)
            {
                _loggingService.LogError("Failed to write event report to disk", ex);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _loggingService.LogError("Access denied while saving event report", ex);
                throw;
            }
            catch (JsonException ex)
            {
                _loggingService.LogError("Failed to serialize event report", ex);
                throw;
            }
        }

        private void SaveCrashReport(CrashReport report)
        {
            lock (_fileLock)
            {
                var fileName = $"crash_{report.Timestamp:yyyyMMdd_HHmmss}_{Guid.NewGuid():N}.json";
                var filePath = Path.Combine(_crashReportsPath, fileName);
                var jsonOptions = _jsonOptions ?? _defaultJsonOptions;
                var json = JsonSerializer.Serialize(report, jsonOptions);
                File.WriteAllText(filePath, json);
            }
        }

        private void SaveEventReport(EventReport report)
        {
            lock (_fileLock)
            {
                var fileName = $"event_{report.Timestamp:yyyyMMdd_HHmmss}_{Guid.NewGuid():N}.json";
                var filePath = Path.Combine(_eventsPath, fileName);
                var jsonOptions = _jsonOptions ?? _defaultJsonOptions;
                var json = JsonSerializer.Serialize(report, jsonOptions);
                File.WriteAllText(filePath, json);
            }
        }

        private async Task ValidateDirectoryAccessAsync()
        {
            var testFile = Path.Combine(_crashReportsPath, $"test_{Guid.NewGuid():N}.tmp");
            try
            {
                await File.WriteAllTextAsync(testFile, string.Empty).ConfigureAwait(false);
                await Task.Delay(10).ConfigureAwait(false); // Ensure file system catches up
                File.Delete(testFile);
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException($"Cannot write to crash reports directory: {_crashReportsPath}", ex);
            }

            testFile = Path.Combine(_eventsPath, $"test_{Guid.NewGuid():N}.tmp");
            try
            {
                await File.WriteAllTextAsync(testFile, string.Empty).ConfigureAwait(false);
                await Task.Delay(10).ConfigureAwait(false);
                File.Delete(testFile);
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException($"Cannot write to events directory: {_eventsPath}", ex);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Dispose managed resources
                _initializationLock.Dispose();
            }

            // Dispose unmanaged resources (if any)
            _disposed = true;
        }

        private sealed class CrashReport
        {
            public DateTime Timestamp { get; set; }
            public string ExceptionType { get; set; } = "";
            public string Message { get; set; } = "";
            public string? StackTrace { get; set; }
            public IDictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();
            public string OSVersion { get; set; } = "";
            public string RuntimeVersion { get; set; } = "";
            public int ProcessId { get; set; }
            public string MachineName { get; set; } = "";
            public InnerExceptionInfo? InnerException { get; set; }
        }

        private sealed class InnerExceptionInfo
        {
            public string Type { get; set; } = "";
            public string Message { get; set; } = "";
            public string? StackTrace { get; set; }
        }

        private sealed class EventReport
        {
            public DateTime Timestamp { get; set; }
            public string EventName { get; set; } = "";
            public IDictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
            public int ProcessId { get; set; }
            public string MachineName { get; set; } = "";
        }
    }
}