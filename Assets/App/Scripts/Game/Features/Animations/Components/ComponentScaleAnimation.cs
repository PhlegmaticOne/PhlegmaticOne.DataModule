using App.Scripts.Game.Features.Animations.Components.Base;

namespace App.Scripts.Game.Features.Animations.Components {
    public enum BlockScaleAnimationBehavior {
        BasedOnY,
        BasedOnX,
        BasedOnYSpeed
    }
    
    public class ComponentScaleAnimation : IBlockAnimationComponent {
        public float MaxScale;
        public BlockScaleAnimationBehavior ScaleAnimationBehavior;
    }
}