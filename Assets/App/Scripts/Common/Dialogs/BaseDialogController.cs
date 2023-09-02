using System;
using System.Threading.Tasks;
using App.Scripts.Common.Dialogs.Animators;
using App.Scripts.Common.Dialogs.Manager;
using App.Scripts.Common.Input;
using App.Scripts.Common.Input.Base;
using App.Scripts.Common.Pools.PoolableTypes;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Scripts.Common.Dialogs {
    public class BaseDialogController : PoolableDialog {
        [SerializeField] private Button[] _closeButtons;
        [SerializeField] private BaseDialogAnimator _dialogAnimator;
        
        private IDialogsManager _dialogsManager;
        private IInputLocker _inputLocker;

        public event Action OnClosed;
        
        [Inject]
        private void Construct(IDialogsManager dialogsManager, IInputLocker inputLocker) {
            _inputLocker = inputLocker;
            _dialogsManager = dialogsManager;
        }

        public override void OnInitialize() {
            _dialogAnimator.Setup();
            
            foreach (var button in _closeButtons) {
                button.onClick.AddListener(CloseDialog);
            }
        }

        public UniTask ShowDialog() {
            return _inputLocker.ExecuteInLocked(async() => {
                await OnShowing();
                await _dialogAnimator.PlayShowAnimation();
            });
        }

        public UniTask CloseDialogByManager() {
            return _inputLocker.ExecuteInLocked(async () => {
                await _dialogAnimator.PlayCloseAnimation();
                OnClosing();
                OnClosed?.Invoke();
                OnClosed = null;
            });
        }
        
        protected virtual Task OnShowing() => Task.CompletedTask;
        protected virtual void OnClosing() { }
        private async void CloseDialog() => await _dialogsManager.CloseDialog(this);
    }
}