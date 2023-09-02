using System.Collections.Generic;
using App.Scripts.Common.Animations;
using App.Scripts.Common.Extensions;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Scripts.Common.Dialogs.Animators {
    public class DefaultDialogAnimator : BaseDialogAnimator {
        [Header("Alpha Components")]
        [SerializeField] private CanvasGroup _contentCanvas; 
        [SerializeField] private Image _backgroundImage;
        
        [Header("RectTransform Components")]
        [SerializeField] private bool _isPlayMoveAnimation = true;
        [SerializeField] private RectTransform _contentRectTransform;
        
        private DialogAnimatorConfig _config;

        [Inject]
        private void Construct(DialogAnimatorConfig config) {
            _config = config;
        }

        public override void Setup() {
            _contentRectTransform.anchoredPosition = _config.PositionHide;
            _contentCanvas.alpha = 0f;
            _backgroundImage.Transparent();
        }
        
        public override UniTask PlayShowAnimation() {
            _backgroundImage.Transparent();
            _contentCanvas.Transparent();

            var showTasks = new List<UniTask> {
                _backgroundImage.UniFade(_config.BackgroundAlphaShow, _config.BackgroundShow),
                _contentCanvas.UniOpaque(_config.ContentShow)
            };

            if (_isPlayMoveAnimation) {
                showTasks.Add(_contentRectTransform.UniAnchoredPos(_config.PositionShow, _config.MoveShow));
            }
            else {
                _contentRectTransform.anchoredPosition = _config.PositionShow;
            }

            return UniTask.WhenAll(showTasks);
        }

        public override UniTask PlayCloseAnimation() {
            var hideTasks = new List<UniTask> {
                _backgroundImage.UniTransparent(_config.BackgroundHide),
                _contentCanvas.UniTransparent(_config.ContentHide)
            };
            
            if (_isPlayMoveAnimation) {
                hideTasks.Add(_contentRectTransform.UniAnchoredPos(_config.PositionHide, _config.MoveHide));
            }

            return UniTask.WhenAll(hideTasks);
        }
    }
}