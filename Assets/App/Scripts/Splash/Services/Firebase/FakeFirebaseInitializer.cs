using System.Threading.Tasks;

namespace App.Scripts.Splash.Services.Firebase {
    public class FakeFirebaseInitializer : IFirebaseInitializer {
        public Task InitializeAsync() => Task.CompletedTask;
    }
}