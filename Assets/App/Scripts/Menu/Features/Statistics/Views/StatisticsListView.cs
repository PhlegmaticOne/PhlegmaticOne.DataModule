using App.Scripts.Common.ViewModels;
using App.Scripts.Menu.Features.Statistics.Models;
using App.Scripts.Menu.Features.Statistics.ViewModels;
using UnityEngine;

namespace App.Scripts.Menu.Features.Statistics.Views {
    public class StatisticsListView : ViewModelListView<StatisticsBlockInfo, StatisticsListViewItem> {
        [SerializeField] private RectTransform _contentTransform;
        protected override RectTransform ContentTransform => _contentTransform;

        public void SubscribeViews(StatisticsViewModel viewModel) {
            foreach (var (view, model) in ViewModelEntries()) {
                view.SetButtonCommand(viewModel.AddSliceCommand, model);
            }
        }
    }
}