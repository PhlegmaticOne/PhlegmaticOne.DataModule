using App.Scripts.Game.Features.Animations.Components.Base;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.Animations.Components {
    public class ComponentRotationAnimation : IBlockAnimationComponent {
        public float Speed;
        public int Direction;
    }
}