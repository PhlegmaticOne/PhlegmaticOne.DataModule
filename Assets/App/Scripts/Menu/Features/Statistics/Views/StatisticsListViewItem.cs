using App.Scripts.Common.ViewModels;
using App.Scripts.Menu.Features.Statistics.Configs;
using App.Scripts.Menu.Features.Statistics.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Scripts.Menu.Features.Statistics.Views
{
    public class StatisticsListViewItem : ViewModelListViewItem<StatisticsBlockInfo> {
        [SerializeField] private Image _blockTypeImage;
        [SerializeField] private TextMeshProUGUI _sliceCountText;
        
        private StatisticsViewConfig _viewConfig;

        [Inject]
        public void Construct(StatisticsViewConfig viewConfig) {
            _viewConfig = viewConfig;
        }
        
        public override void UpdateView(StatisticsBlockInfo model) {
            var sprite = _viewConfig.GetSprite(model.BlockType);
            _blockTypeImage.sprite = sprite;
            _sliceCountText.text = model.SlicesCount.ToString();
        }
    }
}