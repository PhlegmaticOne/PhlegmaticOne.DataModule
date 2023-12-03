using System.Threading.Tasks;
using Firebase.Analytics;
using Firebase.Auth;
using GoogleSignIn;
using PhlegmaticOne.Auth.Google;
using PhlegmaticOne.Auth.Google.Log;
using PhlegmaticOne.Logger.Base;

namespace PhlegmaticOne.Auth.App.Modules.Auth.Editor {
    public class EditorAuthProvider : IAuthProvider {
        private const string UserIdPropertyName = "User_Id";
        private const string TestUserEmail = "editor@gmail.com";
        private const string TestUserPassword = "Editor!123";
        
        private readonly ILogger _logger;
        private FirebaseAuth _firebaseAuth;

        public EditorAuthProvider(ILogger logger) {
            _logger = logger;
        }
        
        public async Task SignInAsync() {
            InitAuthFields();
            var authResult = await _firebaseAuth.SignInWithEmailAndPasswordAsync(TestUserEmail, TestUserPassword);
            var userId = authResult.User.UserId;
            FirebaseAnalytics.SetUserProperty(UserIdPropertyName, userId);
        }

        public void SignOut() {
            _firebaseAuth.SignOut();
            _firebaseAuth.Dispose();
            _logger.LogObject(new GoogleSignOutLogModel());
        }

        private void InitAuthFields() {
            _firebaseAuth = FirebaseAuth.DefaultInstance;
        }
    }
}