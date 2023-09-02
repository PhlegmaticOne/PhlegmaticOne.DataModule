using System.IO;

namespace PhlegmaticOne.Logger.MessageFormater {
    public class LogMessageEditorFormatter : ILogMessageFormatter {
        public string Format(string logMessage, string callerPath) {
            var caller = Path.GetFileNameWithoutExtension(callerPath);
            return $"{caller}: {logMessage}";
        }
    }
}