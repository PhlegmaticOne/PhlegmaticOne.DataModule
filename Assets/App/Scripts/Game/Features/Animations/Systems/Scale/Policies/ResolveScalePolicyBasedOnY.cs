using App.Scripts.Game.Features.Animations.Components;
using App.Scripts.Game.Features.Animations.Models;
using App.Scripts.Game.Features.Blocks;
using App.Scripts.Game.Features.Common;

namespace App.Scripts.Game.Features.Animations.Systems.Scale.Policies {
    public class ResolveScalePolicyBasedOnY : IResolveScalePolicy {
        private readonly float _halfHeight;
        
        public ResolveScalePolicyBasedOnY(CameraProvider cameraProvider) {
            _halfHeight = cameraProvider.Camera.orthographicSize;
        }

        public BlockScaleAnimationBehavior ScaleAnimationBehavior => BlockScaleAnimationBehavior.BasedOnY;
        
        public ResolveScalePolicyData GetScaleData(Block block) {
            return new ResolveScalePolicyData {
                CurrentValue = block.transform.position.y,
                MaxValue = _halfHeight
            };
        }
    }
}