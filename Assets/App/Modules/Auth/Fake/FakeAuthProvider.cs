using System.Threading.Tasks;
using PhlegmaticOne.Logger.Base;

namespace PhlegmaticOne.Auth.Fake {
    public class FakeAuthProvider : IAuthProvider {
        private readonly ILogger _logger;

        public FakeAuthProvider(ILogger logger) {
            _logger = logger;
        }
        
        public Task SignInAsync() {
            _logger.LogMessage("Fake logging succeed!");
            return Task.CompletedTask;
        }

        public void SignOut() {
            _logger.LogMessage("Fake sign out succeed!");
        }
    }
}