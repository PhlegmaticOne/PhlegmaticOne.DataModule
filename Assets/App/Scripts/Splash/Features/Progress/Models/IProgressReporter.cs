using System.Threading;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace App.Scripts.Splash.Features.Progress.Models {
    public interface IProgressReporter { 
        event UnityAction<ProgressModel> Progress;
        Task ProgressAsync(CancellationToken cancellationToken);
    }
}