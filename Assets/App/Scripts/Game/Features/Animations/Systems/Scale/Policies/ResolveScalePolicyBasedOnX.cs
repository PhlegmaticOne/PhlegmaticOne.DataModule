using App.Scripts.Game.Features.Animations.Components;
using App.Scripts.Game.Features.Animations.Models;
using App.Scripts.Game.Features.Blocks;
using App.Scripts.Game.Features.Common;

namespace App.Scripts.Game.Features.Animations.Systems.Scale.Policies {
    public class ResolveScalePolicyBasedOnX : IResolveScalePolicy {
        private readonly float _halfWidth;
        
        public ResolveScalePolicyBasedOnX(CameraProvider cameraProvider) {
            _halfWidth = cameraProvider.Camera.orthographicSize * cameraProvider.Camera.aspect;
        }
        
        public BlockScaleAnimationBehavior ScaleAnimationBehavior => BlockScaleAnimationBehavior.BasedOnX;
        public ResolveScalePolicyData GetScaleData(Block block) {
            return new ResolveScalePolicyData {
                CurrentValue = block.transform.position.x,
                MaxValue = _halfWidth
            };
        }
    }
}