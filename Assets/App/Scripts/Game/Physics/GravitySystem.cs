using App.Scripts.Game.Common;
using App.Scripts.Game.Infrastructure.Ecs;

namespace App.Scripts.Game.Physics {
    public class GravitySystem : SystemBase {
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
            if (!entity.TryGetComponent<TransformComponent>(out var transformComponent) ||
                !entity.TryGetComponent<GravityComponent>(out var gravityComponent)) {
                return;
            }

            var speed = gravityComponent.Speed;
            var transform = transformComponent.Transform;
            transform.position += speed * deltaTime;
        }

        private static void UpdateSpeed(Entity entity, float deltaTime) {
            if (!entity.TryGetComponent<GravityComponent>(out var gravityComponent)) {
                return;
            }

            var acceleration = gravityComponent.Acceleration;
            gravityComponent.Speed += acceleration * deltaTime;
        }
    }
}