using App.Scripts.Game.Infrastructure.Ecs.Components.Base;

namespace App.Scripts.Game.Infrastructure.Ecs.Components {
    public class ComponentTimer : IComponent {
        public float CurrentTime;
        public float Time;

        public bool IsEnd => CurrentTime >= Time;
    }
}