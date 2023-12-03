using App.Scripts.Common.ViewModels;
using App.Scripts.Menu.Screen.Animations;
using App.Scripts.Menu.Screen.ViewModel;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Menu.Screen {
    public class MenuScreenView : ViewModelViewInject<MenuScreenViewModel> {
        [SerializeField] private ViewModelCommandButton _playButton;
        [SerializeField] private ViewModelCommandButton _exitButton;
        [SerializeField] private ViewModelCommandButton _showStatisticsButton;
        [SerializeField] private MenuScreenAnimator _animator;

        public UniTask ShowAnimate() {
            return _animator.PlayAppearAnimation();
        }

        protected override void OnInitializing() {
            _playButton.Setup(ViewModel.PlayCommand);
            _exitButton.Setup(ViewModel.ExitCommand);
            _showStatisticsButton.Setup(ViewModel.ShowStatisticsCommand);
        }

        protected override void OnDisposing() {
            _playButton.Dispose();
            _exitButton.Dispose();
            _showStatisticsButton.Dispose();
        }
    }
}