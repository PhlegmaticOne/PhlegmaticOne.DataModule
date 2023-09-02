using System;
using System.Collections.Generic;
using App.Scripts.Common.Pools;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Common.Dialogs.Manager {
    public class DialogsManager : IDialogsManager {
        private readonly DialogsPool _dialogsPool;
        private readonly DialogsManagerSettings _settings;
        private readonly List<BaseDialogController> _activeDialogs;
        
        public DialogsManager(DialogsPool dialogsPool, DialogsManagerSettings settings) {
            _dialogsPool = dialogsPool;
            _settings = settings;
            _activeDialogs = new List<BaseDialogController>();
        }

        public async UniTask<T> ShowDialog<T>(Action<T> initAction) where T : BaseDialogController {
            var dialog = _dialogsPool.GetFromPool<T>(_settings.DialogsTransform);
            dialog.transform.SetAsLastSibling();
            initAction?.Invoke(dialog);
            _activeDialogs.Add(dialog);
            await dialog.ShowDialog();
            return dialog;
        }

        public async UniTask CloseDialog(BaseDialogController dialog) {
            if (!_activeDialogs.Contains(dialog)) {
                return;
            }
            
            _activeDialogs.Remove(dialog);
            await dialog.CloseDialogByManager();
            _dialogsPool.ReturnToPool(dialog);
        }
    }
}