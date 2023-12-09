﻿using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Game.Features.Health.Views
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image _heartImage;
        [SerializeField] private Image _shadowImage;
        [SerializeField] private float _fadeDuration = 1f;

        private void Awake()
        {
            HideImage(_heartImage);
            HideImage(_shadowImage);
        }

        public void Show()
        {
            ShowImage(_heartImage);
            ShowImage(_shadowImage);
        }

        public void Hide()
        {
            var position = transform.position;
            transform.position = position;
            FadeAway(_heartImage);
            FadeAway(_shadowImage);
        }

        private void OnDestroy()
        {
            Kill(_heartImage);
            Kill(_shadowImage);
        }

        private static void HideImage(Image image)
        {
            var color = image.color;
            image.color = new Color(color.r, color.g, color.b, 0);
        }

        private static void Kill(Image image) => image.DOKill();
        private void ShowImage(Image image) => image.DOFade(1, _fadeDuration);
        private void FadeAway(Image image)
        {
            image.DOFade(0, _fadeDuration).OnComplete(() => Destroy(gameObject));
        }
    }
}