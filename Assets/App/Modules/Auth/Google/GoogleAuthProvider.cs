using System.Threading.Tasks;
using Firebase.Analytics;
using Firebase.Auth;
using GoogleSignIn;
using PhlegmaticOne.Auth.Google.Log;
using ILogger = PhlegmaticOne.Logger.Base.ILogger;

namespace PhlegmaticOne.Auth.Google {
    public class GoogleAuthProvider : IAuthProvider {
        private const string UserIdPropertyName = "User_Id";
        
        private readonly IGoogleAuthOptions _googleAuthOptions;
        private readonly ILogger _logger;

        private FirebaseAuth _firebaseAuth;
        private GoogleSignIn.GoogleSignIn _googleSignIn;

        public GoogleAuthProvider(IGoogleAuthOptions googleAuthOptions, ILogger logger) {
            _googleAuthOptions = googleAuthOptions;
            _logger = logger;
            SetupGoogleSignIn();
        }
        
        public async Task SignInAsync() {
            InitAuthFields();
            var user = await SignInUser();
            _logger.LogObject(new GoogleSingInSucceedLogModel(user));
        }

        public void SignOut() {
            _googleSignIn.SignOut();
            _googleSignIn.Disconnect();
            _firebaseAuth.SignOut();
            _firebaseAuth.Dispose();
            _logger.LogObject(new GoogleSignOutLogModel());
        }

        private async Task<GoogleSignInUser> SignInUser() {
            var user = await _googleSignIn.SignIn();
            var credential = Firebase.Auth.GoogleAuthProvider.GetCredential(user.IdToken, null);
            var firebaseUser = await _firebaseAuth.SignInWithCredentialAsync(credential);
            FirebaseAnalytics.SetUserProperty(UserIdPropertyName, firebaseUser.UserId);
            return user;
        }

        private void InitAuthFields() {
            _firebaseAuth = FirebaseAuth.DefaultInstance;
            _googleSignIn = GoogleSignIn.GoogleSignIn.DefaultInstance;
        }

        private void SetupGoogleSignIn() {
            GoogleSignIn.GoogleSignIn.Configuration = new GoogleSignInConfiguration {
                WebClientId = _googleAuthOptions.WebClientId,
                RequestEmail = true,
                RequestIdToken = true,
                UseGameSignIn = false
            };
        }
    }
}