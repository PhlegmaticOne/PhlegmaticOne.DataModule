using System.Collections.Generic;
using App.Scripts.Game.Features.Blocks.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Configs {
    [CreateAssetMenu(fileName = "BlockConfigsProvider", menuName = "Game/Blocks/Blocks Configs Provider")]
    public class BlockConfigsProvider : SerializedScriptableObject {
        [SerializeField] private Dictionary<BlockType, BlockConfigScriptableObject> _blockConfigs;

        public BlockConfigScriptableObject GetConfig(BlockType blockType) => _blockConfigs[blockType];
    }
}