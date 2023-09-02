using System.Threading.Tasks;
using App.Scripts.Common.Dialogs;
using App.Scripts.Common.ViewModels;
using App.Scripts.Menu.Features.Statistics.ViewModels;
using UnityEngine;

namespace App.Scripts.Menu.Features.Statistics.Dialog {
    public class StatisticsDialog : BaseDialogController {
        [SerializeField] private ViewModelView<StatisticsViewModel> _statisticsView;

        protected override Task OnShowing() {
            return _statisticsView.InitializeAsync();
        }

        protected override void OnClosing() {
            _statisticsView.Dispose();
        }
    }
}