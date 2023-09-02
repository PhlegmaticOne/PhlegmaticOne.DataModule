namespace PhlegmaticOne.Logger.MessageFormater {
    public interface ILogMessageFormatter {
        string Format(string logMessage, string callerPath);
    }
}