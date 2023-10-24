using System.Collections.Generic;
using System.Linq;
using App.Scripts.Common.Utils;
using App.Scripts.Game.Features.Animations.Components.Base;
using App.Scripts.Game.Features.Animations.Configs;
using App.Scripts.Game.Features.Animations.Models;

namespace App.Scripts.Game.Features.Animations.Factories {
    public class BlockAnimationFactory : IBlockAnimationFactory {
        private readonly BlockAnimationsConfig _blockAnimationsConfig;

        public BlockAnimationFactory(BlockAnimationsConfig blockAnimationsConfig) {
            _blockAnimationsConfig = blockAnimationsConfig;
        }
        
        public IEnumerable<IBlockAnimationComponent> CreateAnimationComponents(BlockAnimationType blockAnimationType, int direction) {
            return EnumUtils.Values<BlockAnimationType>()
                .Where(animationType => (blockAnimationType & animationType) != 0)
                .Select(x => _blockAnimationsConfig.GetBlockAnimationConfig(x))
                .Select(x => x.CreateAnimationComponent(direction));
        }
    }
}