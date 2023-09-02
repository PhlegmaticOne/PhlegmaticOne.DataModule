using App.Scripts.Common.ViewModels;
using App.Scripts.Menu.Features.Statistics.Configs;
using App.Scripts.Menu.Features.Statistics.Models;
using PhlegmaticOne.ViewModels.Commands;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Scripts.Menu.Features.Statistics.Views {
    public class StatisticsListViewItem : ViewModelListViewItem<StatisticsBlockInfo> {
        [SerializeField] private Image _blockTypeImage;
        [SerializeField] private TextMeshProUGUI _sliceCountText;
        [SerializeField] private ViewModelCommandButton _addSliceButton;
        
        private StatisticsViewConfig _viewConfig;

        [Inject]
        public void Construct(StatisticsViewConfig viewConfig) {
            _viewConfig = viewConfig;
        }

        public void SetButtonCommand(IRelayCommand relayCommand, StatisticsBlockInfo model) {
            _addSliceButton.Setup(relayCommand, model);
        }
        
        public override void UpdateView(StatisticsBlockInfo model) {
            var sprite = _viewConfig.GetSprite(model.BlockType);
            _blockTypeImage.sprite = sprite;
            _sliceCountText.text = model.SlicesCount.ToString();
        }

        public override void OnReset() {
            _addSliceButton.Dispose();
        }
    }
}