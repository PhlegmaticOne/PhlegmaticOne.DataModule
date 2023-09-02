using App.Scripts.Common.Animations;
using UnityEngine;

namespace App.Scripts.Menu.Screen.Animations {
    [CreateAssetMenu(
        fileName = "MenuScreenAnimatorConfig",
        menuName = "Menu/Screen/Menu Screen Animator Config")]
    public class MenuScreenAnimatorConfig : ScriptableObject {
        [SerializeField] private TweenAnimationInfo _houses;
        [SerializeField] private TweenAnimationInfo _lights;
        [SerializeField] private TweenAnimationInfo _fruitNinja;
        [SerializeField] private TweenAnimationInfo _playerScore;
        [SerializeField] private TweenAnimationInfo _playerScoreText;
        [SerializeField] private TweenAnimationInfo _buttons;

        public TweenAnimationInfo Houses => _houses;
        public TweenAnimationInfo Lights => _lights;
        public TweenAnimationInfo PlayerScore => _playerScore;
        public TweenAnimationInfo FruitNinja => _fruitNinja;
        public TweenAnimationInfo PlayerScoreText => _playerScoreText;
        public TweenAnimationInfo Buttons => _buttons;
    }
}