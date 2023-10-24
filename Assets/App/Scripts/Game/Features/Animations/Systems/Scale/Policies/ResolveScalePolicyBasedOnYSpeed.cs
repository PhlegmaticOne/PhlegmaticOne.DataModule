using App.Scripts.Game.Features.Animations.Components;
using App.Scripts.Game.Features.Animations.Models;
using App.Scripts.Game.Features.Blocks;
using App.Scripts.Game.Features.Physics.Components;

namespace App.Scripts.Game.Features.Animations.Systems.Scale.Policies {
    public class ResolveScalePolicyBasedOnYSpeed : IResolveScalePolicy {
        public BlockScaleAnimationBehavior ScaleAnimationBehavior => BlockScaleAnimationBehavior.BasedOnYSpeed;
        public ResolveScalePolicyData GetScaleData(Block block) {
            var gravityComponent = block.Entity.GetComponent<ComponentGravity>();
            return new ResolveScalePolicyData {
                CurrentValue = gravityComponent.Speed.y,
                MaxValue = gravityComponent.StartSpeed.y
            };
        }
    }
}