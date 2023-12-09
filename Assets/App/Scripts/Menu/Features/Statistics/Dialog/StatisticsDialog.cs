using System.Threading.Tasks;
using App.Scripts.Common.Dialogs;
using App.Scripts.Common.ViewModels;
using App.Scripts.Menu.Features.Statistics.ViewModels;
using UnityEngine;

namespace App.Scripts.Menu.Features.Statistics.Dialog {
    public class StatisticsDialog : BaseDialogController {
        [SerializeField] private ViewModelView<StatisticsViewModel> _statisticsView;
        
        public string UserId { get; set; }

        protected override Task OnShowing()
        {
            _statisticsView.ViewModel.UserId = UserId;
            return _statisticsView.InitializeAsync();
        }

        protected override void OnClosing() {
            _statisticsView.Dispose();
        }
    }
}