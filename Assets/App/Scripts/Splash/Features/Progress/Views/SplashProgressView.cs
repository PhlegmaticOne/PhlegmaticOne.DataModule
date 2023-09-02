using App.Scripts.Common.ViewModels;
using App.Scripts.Splash.Features.Progress.Models;
using App.Scripts.Splash.Features.Progress.ViewModels;
using PhlegmaticOne.ViewModels.Extensions;
using TMPro;
using UnityEngine;

namespace App.Scripts.Splash.Features.Progress.Views {
    public class SplashProgressView : ViewModelViewInject<ProgressReporterViewModel> {
        private const string Percentage = "%";
        
        [SerializeField] private TextMeshProUGUI _progressText;
        [SerializeField] private CircleAnimator _circleAnimator;
        
        protected override void OnInitializing() {
            ViewModel.Subscribe(x => x.Progress, UpdateProgress);
            _circleAnimator.Animate();
        }

        protected override void OnDisposing() {
            _circleAnimator.DestroyAnimation();
        }

        private void UpdateProgress(ProgressModel progress) {
            _progressText.text = FormatProgressView(progress.ProgressInt);
        }

        private static string FormatProgressView(int progress) {
            return string.Concat(progress, Percentage);
        }
    }
}