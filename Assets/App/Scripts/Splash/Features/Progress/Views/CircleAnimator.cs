using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Splash.Features.Progress.Views {
    public class CircleAnimator : MonoBehaviour {
        [SerializeField] private RectTransform _parentTransform;
        [SerializeField] private RectTransform _targetTransform;
        [SerializeField] private float _animationTime;
        [SerializeField] private Ease _ease;

        public void Animate() {
            var parentSize = _parentTransform.rect.width / 2;
            DOVirtual
                .Int(0, 360, _animationTime, a => SetTargetPosition(a, parentSize))
                .SetEase(_ease)
                .SetLoops(-1)
                .SetId(this)
                .ToUniTask();
        }

        public void DestroyAnimation() => DOTween.Kill(this);

        private void SetTargetPosition(int angleInDegrees, float parentSize) {
            var angle = Mathf.Deg2Rad * angleInDegrees;
            var x = Mathf.Sin(angle) * parentSize;
            var y = Mathf.Cos(angle) * parentSize;
            _targetTransform.localPosition = new Vector3(x, y);
        }
    }
}