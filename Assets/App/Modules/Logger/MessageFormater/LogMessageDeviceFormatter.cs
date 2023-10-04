using System.IO;
using System.Linq;

namespace PhlegmaticOne.Logger.MessageFormater {
    public class LogMessageDeviceFormatter : ILogMessageFormatter {
        public string Format(string logMessage, string callerPath) {
            var caller = Path.GetFileNameWithoutExtension(callerPath);
            return $"{caller}: {logMessage}";
        }
    }
}