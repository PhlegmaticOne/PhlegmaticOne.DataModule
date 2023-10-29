using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Physics.Systems {
    public class SystemGravity : SystemBase {
        private IComponentsFilter _filter;
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentBlock>()
                .With<ComponentGravity>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var transformComponent = entity.GetComponent<ComponentBlock>();
                var gravityComponent = entity.GetComponent<ComponentGravity>();
                var speed = gravityComponent.Speed;
                var transform = transformComponent.Block.transform;
                transform.position += speed * (deltaTime / gravityComponent.DeltaTimeDivider);
            }
        }

        public override void OnFixedUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var gravityComponent = entity.GetComponent<ComponentGravity>();
                var acceleration = gravityComponent.Acceleration;
                gravityComponent.Speed += acceleration * (deltaTime / gravityComponent.DeltaTimeDivider);
            }
        }
    }
}