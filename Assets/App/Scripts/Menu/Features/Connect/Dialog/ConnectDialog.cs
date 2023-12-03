using App.Scripts.Common.Dialogs;
using App.Scripts.Common.ViewModels;
using Assets.App.Scripts.Menu.Features.Connect.ViewModel;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.App.Scripts.Menu.Features.Connect.Dialog
{
    public class ConnectDialog : BaseDialogController
    {
        [SerializeField] private ViewModelView<ConnectDialogViewModel> _view;

        protected override Task OnShowing()
        {
            return _view.InitializeAsync();
        }

        protected override void OnClosing()
        {
            _view.Dispose();
        }
    }
}
