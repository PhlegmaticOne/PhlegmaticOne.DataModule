using System.Threading.Tasks;
using Firebase.Analytics;
using Firebase.Auth;
using PhlegmaticOne.Auth.Assets.App.Modules.Auth;
using PhlegmaticOne.Auth.Google.Log;
using PhlegmaticOne.Logger.Base;

namespace PhlegmaticOne.Auth.App.Modules.Auth.Editor
{
    public class EmailPasswordAuthProvider : IAuthProvider {
        private const string UserIdPropertyName = "User_Id";

        private readonly ILogger _logger;

        private FirebaseAuth _firebaseAuth;

        public EmailPasswordAuthProvider(ILogger logger) {
            _logger = logger;
        }
        
        public async Task SignInAsync(IAuthSource authSource) {
            InitAuthFields();

            var authData = await authSource.GetAuthDataAsync();
            var authResult = await Authenticate(authData);
            
            SetupAnalytics(authResult);
        }

        public void SignOut() {
            _firebaseAuth.SignOut();
            _firebaseAuth.Dispose();
            _logger.LogObject(new GoogleSignOutLogModel());
        }

        private Task<AuthResult> Authenticate(AuthData authData)
        {
            if (authData.IsSignIn)
            {
                return _firebaseAuth.SignInWithEmailAndPasswordAsync(authData.Email, authData.Password);
            }

            return _firebaseAuth.CreateUserWithEmailAndPasswordAsync(authData.Email, authData.Password);
        }

        private void SetupAnalytics(AuthResult authResult)
        {
            var userId = authResult.User.UserId;
            FirebaseAnalytics.SetUserProperty(UserIdPropertyName, userId);
        }

        private void InitAuthFields() {
            _firebaseAuth = FirebaseAuth.DefaultInstance;
        }
    }
}