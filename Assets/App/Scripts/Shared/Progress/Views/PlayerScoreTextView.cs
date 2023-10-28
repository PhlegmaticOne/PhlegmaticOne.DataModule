using App.Scripts.Common.Animations;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace App.Scripts.Menu.Features.Progress.Views {
    public class PlayerScoreTextView : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TweenAnimationInfo _defaultAnimationInfo;

        public UniTask ChangeScoreAnimate(int previousScore, int currentScore) {
            return ChangeScoreAnimate(previousScore, currentScore, _defaultAnimationInfo);
        }

        public UniTask ChangeScoreAnimate(int previousScore, int currentScore, TweenAnimationInfo animationInfo) {
            return DOVirtual
                .Int(previousScore, currentScore, animationInfo.Time, SetScoreInstant)
                .SetEase(animationInfo.Ease)
                .SetId(this)
                .ToUniTask();
        }

        private void SetScoreInstant(int maxScore) {
            _scoreText.text = maxScore.ToString();
        }
    }
}