using App.Scripts.Common.Animations;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Common.Dialogs.Animators {
    [CreateAssetMenu(fileName = "DialogAnimatorConfig", menuName = "Common/Dialogs/Dialog Animator Config")]
    public class DialogAnimatorConfig : ScriptableObject {
        [SerializeField] private TweenAnimationInfo _backgroundShow;
        [SerializeField] private TweenAnimationInfo _contentShow;
        [SerializeField] private TweenAnimationInfo _moveShow;
        [SerializeField] private Vector2 _showPosition;
        [SerializeField] private float _showBackgroundAlpha;
        
        [SerializeField] private TweenAnimationInfo _backgroundHide;
        [SerializeField] private TweenAnimationInfo _contentHide;
        [SerializeField] private TweenAnimationInfo _moveHide;
        [SerializeField] private Vector2 _hidePosition;

        public TweenAnimationInfo BackgroundShow => _backgroundShow;
        public TweenAnimationInfo ContentShow => _contentShow;
        public TweenAnimationInfo MoveShow => _moveShow;
        public Vector2 PositionShow => _showPosition;
        public float BackgroundAlphaShow => _showBackgroundAlpha;
        public TweenAnimationInfo BackgroundHide => _backgroundHide;
        public TweenAnimationInfo ContentHide => _contentHide;
        public TweenAnimationInfo MoveHide => _moveHide;
        public Vector2 PositionHide => _hidePosition;
    }
}