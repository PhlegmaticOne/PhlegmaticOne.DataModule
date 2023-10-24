using System.Linq;
using App.Scripts.Game.Features.Animations.Configs;
using App.Scripts.Game.Features.Animations.Models;
using UnityEngine;

namespace App.Scripts.Game.Features.Animations.Factories {
    public class BlockAnimationTypeFactory : IBlockAnimationTypeFactory {
        private readonly BlockAnimationTypesConfig _config;

        public BlockAnimationTypeFactory(BlockAnimationTypesConfig config) {
            _config = config;
        }
        
        public BlockAnimationType CreateBlockAnimationType() {
            var noneProbability = _config.NoneAnimationProbability;

            if (noneProbability >= Random.value) {
                return BlockAnimationType.None;
            }

            return _config.AnimationProbabilities
                .Where(x => x.Value >= Random.value)
                .Select(x => x.Key)
                .Aggregate(BlockAnimationType.None, (current, animationType) => current | animationType);
        }
    }
}