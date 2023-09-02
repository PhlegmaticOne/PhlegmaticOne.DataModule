using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine.Events;

namespace App.Scripts.Splash.Features.Progress.Models {
    public class AsyncProgressReporter : IProgressReporter {
        private readonly int _progressDeltaTime;
        private readonly int _finalDelay;

        public AsyncProgressReporter(int progressDeltaTime, int finalDelay) {
            _progressDeltaTime = progressDeltaTime;
            _finalDelay = finalDelay;
        }
        
        public event UnityAction<ProgressModel> Progress;
        
        public async Task ProgressAsync(CancellationToken cancellationToken) {
            await foreach (var progress in FullProgress().ToUniTaskAsyncEnumerable()) {
                ReportProgress(progress);
                await UniTask.Delay(_progressDeltaTime, cancellationToken: cancellationToken);
            }
            
            await UniTask.Delay(_finalDelay, cancellationToken: cancellationToken);
        }

        private void ReportProgress(int progress) {
            var model = ProgressModel.FromProgress(progress);
            Progress?.Invoke(model);
        }
        
        private static IEnumerable<int> FullProgress() => Enumerable.Range(1, 100);
    }
}