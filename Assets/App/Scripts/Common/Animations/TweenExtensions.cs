using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Common.Animations {
    public static class TweenExtensions {
        public static UniTask UniAnchoredPos(this RectTransform rectTransform, Vector3 pos, TweenAnimationInfo animationInfo) {
            return rectTransform
                .DOAnchorPos(pos, animationInfo.Time)
                .SetEase(animationInfo.Ease)
                .ToUniTask();
        }
        
        public static UniTask UniScale(this Transform transform, Vector3 scale, TweenAnimationInfo animationInfo) {
            return transform
                .DOScale(scale, animationInfo.Time)
                .SetEase(animationInfo.Ease)
                .ToUniTask();
        }
        
        public static UniTask UniShowScale(this Transform transform, TweenAnimationInfo animationInfo) {
            return UniScale(transform, Vector3.one, animationInfo);
        }
        
        public static UniTask UniHideScale(this Transform transform, TweenAnimationInfo animationInfo) {
            return UniScale(transform, Vector3.zero, animationInfo);
        }
        
        public static UniTask UniFade(this CanvasGroup canvasGroup, float alpha, TweenAnimationInfo animationInfo) {
            return canvasGroup
                .DOFade(alpha, animationInfo.Time)
                .SetEase(animationInfo.Ease)
                .ToUniTask();
        }
        
        public static UniTask UniFade(this Graphic image, float alpha, TweenAnimationInfo animationInfo) {
            return image
                .DOFade(alpha, animationInfo.Time)
                .SetEase(animationInfo.Ease)
                .ToUniTask();
        }
        
        public static UniTask UniOpaque(this CanvasGroup canvasGroup, TweenAnimationInfo animationInfo) {
            return UniFade(canvasGroup, 1, animationInfo);
        }
        
        public static UniTask UniTransparent(this CanvasGroup canvasGroup, TweenAnimationInfo animationInfo) {
            return UniFade(canvasGroup, 0, animationInfo);
        }
        
        public static UniTask UniOpaque(this Image image, TweenAnimationInfo animationInfo) {
            return UniFade(image, 1, animationInfo);
        }
        
        public static UniTask UniTransparent(this Image image, TweenAnimationInfo animationInfo) {
            return UniFade(image, 0, animationInfo);
        }
    }
}