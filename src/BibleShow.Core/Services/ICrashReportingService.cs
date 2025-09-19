using System;
using System.Collections.Generic;

namespace BibleShow.Core.Services
{
    public interface ICrashReportingService
    {
        void Initialize();
        void ReportCrash(Exception exception, IDictionary<string, string>? metadata = null);
        void ReportError(string message, Exception? exception = null, IDictionary<string, string>? metadata = null);
        void LogEvent(string eventName, IDictionary<string, string>? parameters = null);
    }
}