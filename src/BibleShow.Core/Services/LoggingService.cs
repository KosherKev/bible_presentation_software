using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace BibleShow.Core.Services
{
    public sealed class LoggingService : ILoggingService, IDisposable
    {
        private static readonly Action<ILogger, Exception?> LogAccessDeniedError =
            LoggerMessage.Define(LogLevel.Error,
                new EventId(1, nameof(LogAccessDeniedError)),
                "Access denied while creating log directory");

        private static readonly Action<ILogger, Exception?> LogIOError =
            LoggerMessage.Define(LogLevel.Error,
                new EventId(2, nameof(LogIOError)),
                "IO error while creating log directory");

        private static readonly Action<ILogger, string, Exception?> LogErrorWithMessage =
            LoggerMessage.Define<string>(LogLevel.Error,
                new EventId(3, nameof(LogErrorWithMessage)),
                "{Message}");

        private static readonly Action<ILogger, string, Exception?> LogErrorWithMessageAndException =
            LoggerMessage.Define<string>(LogLevel.Error,
                new EventId(4, nameof(LogErrorWithMessageAndException)),
                "{Message}");

        private static readonly Action<ILogger, string, Exception?> LogInformationWithMessage =
            LoggerMessage.Define<string>(LogLevel.Information,
                new EventId(5, nameof(LogInformationWithMessage)),
                "{Message}");

        private static readonly Action<ILogger, string, Exception?> LogWarningWithMessage =
            LoggerMessage.Define<string>(LogLevel.Warning,
                new EventId(6, nameof(LogWarningWithMessage)),
                "{Message}");

        private static readonly Action<ILogger, string, Exception?> LogCriticalWithMessage =
            LoggerMessage.Define<string>(LogLevel.Critical,
                new EventId(7, nameof(LogCriticalWithMessage)),
                "{Message}");

        private static readonly Action<ILogger, string, Exception?> LogCriticalWithMessageAndException =
            LoggerMessage.Define<string>(LogLevel.Critical,
                new EventId(8, nameof(LogCriticalWithMessageAndException)),
                "{Message}");

        private readonly ILogger<LoggingService> _logger;
        private readonly string _logFilePath;
        private readonly object _fileLock = new();
        private bool _disposed;

        ~LoggingService()
        {
            Dispose(false);
        }

        public LoggingService(ILogger<LoggingService>? logger = null)
        {
            _logger = logger ?? NullLogger<LoggingService>.Instance;
            
            try
            {
                var appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BibleShow");
                Directory.CreateDirectory(appDataPath);
                _logFilePath = Path.Combine(appDataPath, "bibleshow.log");
            }
            catch (UnauthorizedAccessException ex)
            {
                // Use console as fallback since logging might not be available
                Console.WriteLine($"Access denied while creating log directory: {ex.Message}");
                // Don't rethrow - continue with limited functionality
                _logFilePath = Path.GetTempFileName();
            }
            catch (IOException ex)
            {
                // Use console as fallback since logging might not be available
                Console.WriteLine($"IO error while creating log directory: {ex.Message}");
                // Don't rethrow - continue with limited functionality
                _logFilePath = Path.GetTempFileName();
            }
            catch (System.Security.SecurityException ex)
            {
                // Use console as fallback for security exceptions
                Console.WriteLine($"Security error while initializing LoggingService: {ex.Message}");
                // Don't rethrow - continue with limited functionality
                _logFilePath = Path.GetTempFileName();
            }
            catch (System.Runtime.InteropServices.ExternalException ex)
            {
                // Use console as fallback for platform interface exceptions
                Console.WriteLine($"Platform interface error while initializing LoggingService: {ex.Message}");
                // Don't rethrow - continue with limited functionality
                _logFilePath = Path.GetTempFileName();
            }
        }

        public void LogInformation(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentException("Message cannot be null or empty", nameof(message));

            LogInformationWithMessage(_logger, message, null);
            WriteToFile("INFO", message);
        }

        public void LogWarning(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentException("Message cannot be null or empty", nameof(message));

            LogWarningWithMessage(_logger, message, null);
            WriteToFile("WARN", message);
        }

        public void LogError(string message, Exception? exception = null)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentException("Message cannot be null or empty", nameof(message));

            if (exception != null)
            {
                LogErrorWithMessageAndException(_logger, message, exception);
                WriteToFile("ERROR", $"{message}\nException: {exception}");
            }
            else
            {
                LogErrorWithMessage(_logger, message, null);
                WriteToFile("ERROR", message);
            }
        }

        public void LogCritical(string message, Exception? exception = null)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentException("Message cannot be null or empty", nameof(message));

            if (exception != null)
            {
                LogCriticalWithMessageAndException(_logger, message, exception);
                WriteToFile("CRITICAL", $"{message}\nException: {exception}");
            }
            else
            {
                LogCriticalWithMessage(_logger, message, null);
                WriteToFile("CRITICAL", message);
            }
        }

        private void WriteToFile(string level, string message)
        {
            try
            {
                var logEntry = $"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss.fff}] [{level}] {message}{Environment.NewLine}";
                
                lock (_fileLock)
                {
                    File.AppendAllText(_logFilePath, logEntry);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied while writing to log file: {ex.Message}");
                Console.WriteLine($"Original log message: [{level}] {message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"IO error while writing to log file: {ex.Message}");
                Console.WriteLine($"Original log message: [{level}] {message}");
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
                // Dispose managed resources (if any)
                // Currently no managed resources to dispose
            }

            // Dispose unmanaged resources (if any)
            // Currently no unmanaged resources to dispose
            _disposed = true;
        }
    }
}