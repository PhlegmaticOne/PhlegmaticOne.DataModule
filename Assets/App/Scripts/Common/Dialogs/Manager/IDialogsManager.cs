using System;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Common.Dialogs.Manager {
    public interface IDialogsManager {
        UniTask<T> ShowDialog<T>(Action<T> initAction = null) where T : BaseDialogController;
        UniTask CloseDialog(BaseDialogController dialog);
    }
}