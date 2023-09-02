using System.IO;
using System.Linq;

namespace PhlegmaticOne.Logger.MessageFormater {
    public class LogMessageDeviceFormatter : ILogMessageFormatter {
        public string Format(string logMessage, string callerPath) {
            var callerFullName = Path.GetFileNameWithoutExtension(callerPath);
            var caller = callerFullName.Split('\\').Last();
            return $"{caller}: {logMessage}";
        }
    }
}