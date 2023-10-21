using App.Scripts.Game.Infrastructure.Ecs.Components;

namespace App.Scripts.Game.Infrastructure.Ecs.Systems {
    public class SystemTimers : SystemBase {
        public override void OnUpdate(float deltaTime) {
            foreach (var entity in World.GetEntities()) {
                if (entity.TryGetComponent<ComponentTimer>(out var componentTimer)) {
                    componentTimer.CurrentTime += deltaTime;
                }
            }
        }
    }
}