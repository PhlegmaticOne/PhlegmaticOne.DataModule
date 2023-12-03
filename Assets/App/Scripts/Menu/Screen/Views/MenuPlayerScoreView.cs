using App.Scripts.Common.Animations;
using App.Scripts.Common.ViewModels;
using App.Scripts.Menu.Features.Progress.ViewModels;
using App.Scripts.Menu.Features.Progress.Views;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Menu.Screen.Views {
    public class MenuPlayerScoreView : ViewModelViewInject<PlayerScoreViewModel> {
        [SerializeField] private PlayerScoreTextView _scoreTextView;

        public UniTask AnimateScoreFromZero(TweenAnimationInfo animationInfo) {
            if (ViewModel.MaxScore == 0) {
                return UniTask.CompletedTask;
            }
            
            return _scoreTextView.ChangeScoreAnimate(0, ViewModel.MaxScore, animationInfo);
        }
    }
}