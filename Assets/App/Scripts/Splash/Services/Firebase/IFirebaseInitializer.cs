using System.Threading.Tasks;

namespace App.Scripts.Splash.Services.Firebase {
    public interface IFirebaseInitializer {
        Task InitializeAsync();
    }
}