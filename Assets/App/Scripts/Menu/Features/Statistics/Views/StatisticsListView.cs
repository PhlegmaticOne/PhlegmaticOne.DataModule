using App.Scripts.Common.ViewModels;
using App.Scripts.Menu.Features.Statistics.Models;
using UnityEngine;

namespace App.Scripts.Menu.Features.Statistics.Views
{
    public class StatisticsListView : ViewModelListView<StatisticsBlockInfo, StatisticsListViewItem> {
        [SerializeField] private RectTransform _contentTransform;
        protected override RectTransform ContentTransform => _contentTransform;
    }
}