using App.Scripts.Common.Dialogs.Manager;
using Cysharp.Threading.Tasks;
using System.Linq;

namespace Assets.App.Scripts.Common.Dialogs
{
    public static class DialogManagerExtensions
    {
        public static UniTask CloseLastDialog(this IDialogsManager manager)
        {
            var dialog = manager.ActiveDialogs.LastOrDefault();

            if (dialog != null)
            {
                return manager.CloseDialog(dialog);
            }

            return UniTask.CompletedTask;
        }
    }
}
