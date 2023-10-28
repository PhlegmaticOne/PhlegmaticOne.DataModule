using App.Scripts.Game.Infrastructure.Ecs.Components.Base;

namespace App.Scripts.Game.Features.Bomb.Components {
    public class ComponentThrowBlocksOnCut : IComponent {
        public float Force;
        public float Radius;
    }
}