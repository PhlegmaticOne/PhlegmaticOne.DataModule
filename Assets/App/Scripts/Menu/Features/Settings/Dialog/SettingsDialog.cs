using App.Scripts.Common.Dialogs;
using App.Scripts.Common.ViewModels;
using Assets.App.Scripts.Menu.Features.Settings.ViewModel;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.App.Scripts.Menu.Features.Settings.Dialog
{
    public class SettingsDialog : BaseDialogController
    {
        [SerializeField] private ViewModelView<SettingsDialogViewModel> _settingsView;

        protected override Task OnShowing()
        {
            return _settingsView.InitializeAsync();
        }

        protected override void OnClosing()
        {
            _settingsView.Dispose();
        }
    }
}
