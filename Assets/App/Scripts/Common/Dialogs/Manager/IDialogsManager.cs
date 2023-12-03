using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Common.Dialogs.Manager {
    public interface IDialogsManager {
        IReadOnlyList<BaseDialogController> ActiveDialogs { get; }
        UniTask<T> ShowDialog<T>(Action<T> initAction = null) where T : BaseDialogController;
        UniTask CloseDialog(BaseDialogController dialog);
    }
}