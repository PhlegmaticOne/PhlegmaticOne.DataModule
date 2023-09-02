using System.Threading.Tasks;
using Firebase;

namespace App.Scripts.Splash.Services.Firebase {
    public class FirebaseInitializer : IFirebaseInitializer {
        public Task InitializeAsync() => FirebaseApp.CheckAndFixDependenciesAsync();
    }
}