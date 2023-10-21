using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Physics {
    public class SystemGravity : SystemBase {
        public override void OnUpdate(float deltaTime) {
            foreach (var entity in World.GetEntities()) {
                MoveEntity(entity, deltaTime);
            }
        }

        public override void OnFixedUpdate(float deltaTime) {
            foreach (var entity in World.GetEntities()) {
                UpdateSpeed(entity, deltaTime);
            }
        }

        private static void MoveEntity(Entity entity, float deltaTime) {
            if (!entity.TryGetComponent<ComponentTransform>(out var transformComponent) ||
                !entity.TryGetComponent<ComponentGravity>(out var gravityComponent)) {
                return;
            }

            var speed = gravityComponent.Speed;
            var transform = transformComponent.Transform;
            transform.position += speed * deltaTime;
        }

        private static void UpdateSpeed(Entity entity, float deltaTime) {
            if (!entity.TryGetComponent<ComponentGravity>(out var gravityComponent)) {
                return;
            }

            var acceleration = gravityComponent.Acceleration;
            gravityComponent.Speed += acceleration * deltaTime;
        }
    }
}