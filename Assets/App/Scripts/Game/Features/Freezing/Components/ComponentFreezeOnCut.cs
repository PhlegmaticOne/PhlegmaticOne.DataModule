using App.Scripts.Game.Infrastructure.Ecs.Components.Base;

namespace App.Scripts.Game.Features.Freezing.Components {
    public class ComponentFreezeOnCut : IComponent {
        public float Force;
        public float Time;
    }
}