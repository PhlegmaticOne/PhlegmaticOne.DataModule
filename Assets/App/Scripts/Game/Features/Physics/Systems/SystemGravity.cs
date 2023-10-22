using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Physics.Systems {
    public class SystemGravity : SystemBase {
        private IComponentsFilter _moveFilter;
        private IComponentsFilter _speedFilter;
        
        public override void OnAwake() {
            _moveFilter = ComponentsFilter.Builder
                .With<ComponentTransform>()
                .With<ComponentGravity>()
                .Build();

            _speedFilter = ComponentsFilter.Builder
                .With<ComponentGravity>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _moveFilter.Apply(World)) {
                var transformComponent = entity.GetComponent<ComponentTransform>();
                var gravityComponent = entity.GetComponent<ComponentGravity>();
                var speed = gravityComponent.Speed;
                var transform = transformComponent.Transform;
                transform.position += speed * deltaTime;
            }
        }

        public override void OnFixedUpdate(float deltaTime) {
            foreach (var entity in _speedFilter.Apply(World)) {
                var gravityComponent = entity.GetComponent<ComponentGravity>();
                var acceleration = gravityComponent.Acceleration;
                gravityComponent.Speed += acceleration * deltaTime;
            }
        }
    }
}