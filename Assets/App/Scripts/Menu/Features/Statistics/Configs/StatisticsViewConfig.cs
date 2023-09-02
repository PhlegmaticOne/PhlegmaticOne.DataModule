using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Menu.Features.Statistics.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Menu.Features.Statistics.Configs {
    [CreateAssetMenu(fileName = "StatisticsViewConfig", menuName = "Menu/Features/Statistics/Statistics View Config")]
    public class StatisticsViewConfig : SerializedScriptableObject {
        [Serializable]
        private class BlockTypeSpriteInfo {
            public StatisticsBlockType BlockType;
            public Sprite Sprite;
        }
        
        [SerializeField] private List<BlockTypeSpriteInfo> _blockTypeSprites;
        private Dictionary<StatisticsBlockType, Sprite> _map;
        
        private void OnEnable() => _map = _blockTypeSprites.ToDictionary(x => x.BlockType, x => x.Sprite);

        public Sprite GetSprite(StatisticsBlockType blockType) => _map[blockType];
    }
}