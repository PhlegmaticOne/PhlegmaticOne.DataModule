using App.Scripts.Common.ViewModels;
using App.Scripts.Menu.Features.Statistics.ViewModels;
using UnityEngine;

namespace App.Scripts.Menu.Features.Statistics.Views {
    public class StatisticsViewModelView : ViewModelViewInject<StatisticsViewModel> {
        [SerializeField] private StatisticsListView _statisticsList;

        protected override void OnInitializing() {
            _statisticsList.Setup(ViewModel.Statistics);
        }

        protected override void OnDisposing() {
            _statisticsList.Dispose();
        }
    }
}