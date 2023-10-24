using System.Collections.Generic;
using App.Scripts.Game.Features.Animations.Configs.Types.Base;
using App.Scripts.Game.Features.Animations.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Features.Animations.Configs {
    [CreateAssetMenu(fileName = "BlockAnimationsConfig", menuName = "Game/Animations/Animations Config")]
    public class BlockAnimationsConfig : SerializedScriptableObject {
        [SerializeField] private Dictionary<BlockAnimationType, BlockAnimationConfig> _animationConfigs;

        public BlockAnimationConfig GetBlockAnimationConfig(BlockAnimationType blockAnimationType) {
            return _animationConfigs[blockAnimationType];
        }
    }
}