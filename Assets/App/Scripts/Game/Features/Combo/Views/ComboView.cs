using App.Scripts.Common.Extensions;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace App.Scripts.Game.Features.Combo.Views {
    public class ComboView : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _comboText;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private RectTransform _rectTransform;

        public Vector2 HalfSize => _rectTransform.rect.size / 2;

        public void SetPosition(Vector2 position) {
            _rectTransform.localPosition = position;
        }

        public void ShowAnimate(int combo, float time) {
            _comboText.text = GetComboText(combo);
            _canvasGroup.Transparent();
            DOTween.Sequence()
                .Append(_canvasGroup.DOFade(1f, time / 2))
                .Append(_canvasGroup.DOFade(0f, time / 2))
                .OnComplete(() => Destroy(gameObject));
        }

        private string GetComboText(int combo) {
            return $"x{combo}";
        }
    }
}