using System.Collections.Generic;
using GoogleSignIn;
using PhlegmaticOne.Logger.Models;

namespace PhlegmaticOne.Auth.Google.Log {
    public class GoogleSingInSucceedLogModel : ILoggable {
        private readonly GoogleSignInUser _user;

        public GoogleSingInSucceedLogModel(GoogleSignInUser user) => _user = user;

        public string GetLogMessage() {
            const string message = "Google user logged successfully\n";
            var userData = string.Join("\n", UserProperties());
            return message + userData;
        }

        private IEnumerable<string> UserProperties() {
            var properties = new Dictionary<string, string> {
                { nameof(_user.Email), _user.Email },
                { nameof(_user.UserId), _user.UserId },
            };
            
            foreach (var propertyInfo in properties) {
                yield return $"{propertyInfo.Key}: {propertyInfo.Value}";
            }
        }
    }
}