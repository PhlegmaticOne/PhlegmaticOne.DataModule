using System.Collections.Generic;
using App.Scripts.Splash.Features.Progress.Models;
using PhlegmaticOne.ViewModels.Contracts;
using PhlegmaticOne.ViewModels.Properties;

namespace App.Scripts.Splash.Features.Progress.ViewModels {
    public class ProgressReporterViewModel : BaseViewModel {
        private readonly IProgressReporter _progressReporter;

        public ProgressReporterViewModel(IProgressReporter progressReporter) {
            _progressReporter = progressReporter;
            _progressReporter.Progress += AsyncProgressReporterOnProgress;
            Progress = new ReactiveProperty<ProgressModel>();
        }
        
        public ReactiveProperty<ProgressModel> Progress { get; }

        protected override IEnumerable<IReactiveProperty> ReactiveProperties() {
            yield return Progress;
        }

        protected override void OnDisposing() => _progressReporter.Progress -= AsyncProgressReporterOnProgress;
        
        private void AsyncProgressReporterOnProgress(ProgressModel progress) => Progress.Value = progress;
    }
}