using App.Scripts.Common.Pools.PoolableTypes;
using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Menu.Features.Statistics.Configs;
using Assets.App.Scripts.Game.Features.Blocks.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Game.Modes.ByBlocks
{
    public class GameModeTargetBlockView : PoolableUIElement
    {
        [SerializeField] private Image _blockImage;
        [SerializeField] private TextMeshProUGUI _countText;
        [SerializeField] private StatisticsViewConfig _viewConfig;
        
        public void Setup(BlockType blockType, int count)
        {
            var type = BlockTypesMapper.MapFromBlockType(blockType);
            _blockImage.sprite = _viewConfig.GetSprite(type);
            _countText.text = count.ToString();
        }
    }
}