using System;
using PhlegmaticOne.Logger.MessageFormater;
using PhlegmaticOne.Logger.Models;
using UnityEngine;
using ILogger = PhlegmaticOne.Logger.Base.ILogger;

namespace PhlegmaticOne.Logger {
    public class UnityDebugLogger : ILogger {
        private readonly ILogMessageFormatter _logMessageFormatter;

        public UnityDebugLogger(ILogMessageFormatter logMessageFormatter) {
            _logMessageFormatter = logMessageFormatter;
        }
        
        public void LogMessage(string message, string callerName = "") {
            var formatted = _logMessageFormatter.Format(message, callerName);
            Debug.Log(formatted);
        }

        public void LogObject(ILoggable loggableObject, string callerName = "") {
            var message = loggableObject.GetLogMessage();
            var formatted = _logMessageFormatter.Format(message, callerName);
            LogMessage(formatted);
        }
        
        public void LogError(string errorMessage, string callerName = "") {
            var formatted = _logMessageFormatter.Format(errorMessage, callerName);
            Debug.LogError(formatted);
        }

        public void LogException(Exception exception) {
            Debug.LogException(exception);
        }
    }
}