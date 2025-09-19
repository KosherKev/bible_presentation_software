using System;
using System.Globalization;
using System.IO;
using System.Security;

namespace BibleShow.Core.Services
{
    /// <summary>
    /// Provides basic fallback logging functionality when the main logging service is unavailable
    /// </summary>
    public static class FallbackLogger
    {
        private static readonly object _lock = new object();
        private static string? _fallbackLogPath;

        /// <summary>
        /// Initialize the fallback logger with a specific path
        /// </summary>
        public static void Initialize(string? logDirectory = null)
        {
            try
            {
                if (string.IsNullOrEmpty(logDirectory))
                {
                    // Use temporary directory as fallback
                    logDirectory = Path.GetTempPath();
                }

                _fallbackLogPath = Path.Combine(logDirectory, "bibleshow_fallback.log");
                
                // Write initialization message
                Log("INFO", "Fallback logger initialized successfully");
            }
            catch (UnauthorizedAccessException ex)
            {
                // If we can't even initialize the fallback, there's not much we can do
                Console.WriteLine($"Access denied while initializing fallback logger: {ex.Message}");
                _fallbackLogPath = null;
            }
            catch (IOException ex)
            {
                // If we can't even initialize the fallback, there's not much we can do
                Console.WriteLine($"IO error while initializing fallback logger: {ex.Message}");
                _fallbackLogPath = null;
            }
            catch (SecurityException ex)
            {
                // If we can't even initialize the fallback, there's not much we can do
                Console.WriteLine($"Security error while initializing fallback logger: {ex.Message}");
                _fallbackLogPath = null;
            }
        }

        /// <summary>
        /// Log a message with specified level
        /// </summary>
        public static void Log(string level, string message, Exception? exception = null)
        {
            try
            {
                var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                var logMessage = $"[{timestamp}] [{level}] {message}";
                
                if (exception != null)
                {
                    logMessage += $" | Exception: {exception.Message}\n{exception.StackTrace}";
                }

                // Write to console first (most reliable)
                Console.WriteLine(logMessage);

                // Write to file if possible
                if (_fallbackLogPath != null)
                {
                    lock (_lock)
                    {
                        File.AppendAllText(_fallbackLogPath, logMessage + Environment.NewLine);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                // If all else fails, just write to console
                Console.WriteLine($"FALLBACK LOG FAILURE: [{level}] {message}. Access denied: {ex.Message}");
            }
            catch (IOException ex)
            {
                // If all else fails, just write to console
                Console.WriteLine($"FALLBACK LOG FAILURE: [{level}] {message}. IO error: {ex.Message}");
            }
            catch (SecurityException ex)
            {
                // If all else fails, just write to console
                Console.WriteLine($"FALLBACK LOG FAILURE: [{level}] {message}. Security error: {ex.Message}");
            }
        }

        /// <summary>
        /// Log informational message
        /// </summary>
        public static void LogInformation(string message)
        {
            Log("INFO", message, null);
        }

        /// <summary>
        /// Log warning message
        /// </summary>
        public static void LogWarning(string message, Exception? exception = null)
        {
            Log("WARN", message, exception);
        }

        /// <summary>
        /// Log error message
        /// </summary>
        public static void LogError(string message, Exception? exception = null)
        {
            Log("ERROR", message, exception);
        }

        /// <summary>
        /// Log critical error message
        /// </summary>
        public static void LogCritical(string message, Exception? exception = null)
        {
            Log("CRITICAL", message, exception);
        }

        /// <summary>
        /// Get the path to the fallback log file
        /// </summary>
        public static string? LogPath => _fallbackLogPath;
    }
}