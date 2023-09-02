using App.Scripts.Common.Animations;
using App.Scripts.Menu.Screen.Views;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace App.Scripts.Menu.Screen.Animations {
    public class MenuScreenAnimator : MonoBehaviour {
        [SerializeField] private RectTransform _leftHouse;
        [SerializeField] private RectTransform _rightHouse;
        [SerializeField] private RectTransform _lights;
        [SerializeField] private RectTransform _fruitNinja;
        [SerializeField] private MenuPlayerScoreView _menuPlayerScoreView;
        [SerializeField] private CanvasGroup _buttonsPanel;
        
        private MenuScreenAnimatorConfig _config;

        private Vector3 _leftHousePosition;
        private Vector3 _rightHousePosition;
        private Vector3 _lightsPosition;

        [Inject]
        private void Construct(MenuScreenAnimatorConfig animatorConfig) {
            _config = animatorConfig;
        }

        public UniTask PlayAppearAnimation() {
            ToStartState();
            return Play();
        }

        private async UniTask Play() {
            await UniTask.WhenAll(
                _leftHouse.UniAnchoredPos(_leftHousePosition, _config.Houses),
                _rightHouse.UniAnchoredPos(_rightHousePosition, _config.Houses),
                _lights.UniAnchoredPos(_lightsPosition, _config.Lights));
            await _fruitNinja.UniShowScale(_config.FruitNinja);
            await _menuPlayerScoreView.transform.UniShowScale(_config.PlayerScore);
            await _menuPlayerScoreView.AnimateScoreFromZero(_config.PlayerScoreText);
            await _buttonsPanel.UniOpaque(_config.Buttons);
        }

        private void ToStartState() {
            RememberPositions();
            SetStartState();
        }

        private void RememberPositions() {
            _leftHousePosition = _leftHouse.anchoredPosition;
            _rightHousePosition = _rightHouse.anchoredPosition;
            _lightsPosition = _lights.anchoredPosition;
        }

        private void SetStartState() {
            _leftHouse.anchoredPosition = Vector3.zero;
            _rightHouse.anchoredPosition = Vector3.zero;
            _lights.anchoredPosition = Vector3.zero;
            _fruitNinja.localScale = Vector3.zero;
            _menuPlayerScoreView.transform.localScale = Vector3.zero;
            _buttonsPanel.alpha = 0;
        }
    }
}