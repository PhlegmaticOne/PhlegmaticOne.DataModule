using App.Scripts.Common.Extensions;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace App.Scripts.Game.Features.ScoreLabels.Views {
    public class ScoreLabel : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private RectTransform _rectTransform;

        public void SetScore(int score) {
            _scoreText.text = score.ToString();
        }

        public void ShowAnimate(Vector2 from, Vector2 direction, float time) {
            _rectTransform.localPosition = from;
            _canvasGroup.Transparent();

            var fade = DOTween.Sequence()
                .Append(_canvasGroup.DOFade(1, time / 2))
                .Append(_canvasGroup.DOFade(0, time / 2));

            DOTween.Sequence()
                .Append(_rectTransform.DOLocalMove(from + direction, time))
                .Join(fade)
                .OnComplete(() => Destroy(gameObject));
        }
    }
}