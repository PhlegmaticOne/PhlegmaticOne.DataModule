using System.Threading;
using System.Threading.Tasks;

namespace App.Scripts.Splash.Services.Initializer {
    public interface IAppInitializer {
        Task InitializeAsync(CancellationToken cancellationToken);
    }
}