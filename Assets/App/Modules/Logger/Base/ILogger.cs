using System;
using System.Runtime.CompilerServices;
using PhlegmaticOne.Logger.Models;

namespace PhlegmaticOne.Logger.Base {
    public interface ILogger {
        void LogMessage(string message, [CallerFilePath] string callerName = "");
        void LogObject(ILoggable loggableObject, [CallerFilePath] string callerName = "");
        void LogError(string errorMessage, [CallerFilePath] string callerName = "");
        void LogException(Exception exception);
    }
}