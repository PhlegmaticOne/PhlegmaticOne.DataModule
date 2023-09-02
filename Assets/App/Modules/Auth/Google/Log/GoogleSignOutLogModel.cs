using PhlegmaticOne.Logger.Models;

namespace PhlegmaticOne.Auth.Google.Log {
    public class GoogleSignOutLogModel : ILoggable {
        public string GetLogMessage() {
            return "Google user signed out successfully!";
        }
    }
}