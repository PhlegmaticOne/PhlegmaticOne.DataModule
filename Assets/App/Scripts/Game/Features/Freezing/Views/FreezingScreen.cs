using App.Scripts.Common.Extensions;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Game.Features.Freezing.Views {
    public class FreezingScreen : MonoBehaviour {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private float _hideShowTime;

        private float _time;
        private float _remainTime;

        public void Show(float time) {
            _time = time;
            ContinueShow();
            gameObject.SetActive(true);
            _canvasGroup.Transparent();
            _canvasGroup.DOFade(1, _hideShowTime);
            _particleSystem.Play();
        }

        private void Update() {
            _remainTime -= Time.deltaTime;

            if (_remainTime <= 0) {
                _particleSystem.Stop();
                gameObject.SetActive(false);
            }
        }

        public void ContinueShow() {
            _remainTime = _time;
        }
    }
}