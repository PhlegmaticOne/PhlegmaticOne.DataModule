using App.Scripts.Game.Features.Animations.Components;
using App.Scripts.Game.Features.Animations.Models;
using App.Scripts.Game.Features.Blocks;

namespace App.Scripts.Game.Features.Animations.Systems.Scale.Policies {
    public interface IResolveScalePolicy {
        BlockScaleAnimationBehavior ScaleAnimationBehavior { get; }
        ResolveScalePolicyData GetScaleData(Block block);
    }
}