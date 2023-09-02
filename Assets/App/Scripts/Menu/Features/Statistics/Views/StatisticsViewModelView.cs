using App.Scripts.Common.ViewModels;
using App.Scripts.Menu.Features.Statistics.ViewModels;
using UnityEngine;

namespace App.Scripts.Menu.Features.Statistics.Views {
    public class StatisticsViewModelView : ViewModelViewInject<StatisticsViewModel> {
        [SerializeField] private StatisticsListView _statisticsList;
        [SerializeField] private ViewModelCommandButton _saveButton;

        protected override void OnInitializing() {
            _statisticsList.Setup(ViewModel.Statistics);
            _statisticsList.SubscribeViews(ViewModel);
            _saveButton.Setup(ViewModel.SaveCommand);
        }

        protected override void OnDisposing() {
            _statisticsList.Dispose();
            _saveButton.Dispose();
        }
    }
}