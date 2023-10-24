using App.Scripts.Game.Features.Animations.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Animations.Systems.Rotation {
    public class SystemDoAnimationRotation : SystemBase {
        private IComponentsFilter _filter;
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentRotationAnimation>()
                .With<ComponentBlock>()
                .Build();
        }
        
        public override void OnFixedUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var rotationComponent = entity.GetComponent<ComponentRotationAnimation>();
                var block = entity.GetComponent<ComponentBlock>().Block;
                var deltaAngle = deltaTime * rotationComponent.Speed * rotationComponent.Direction;
                block.transform.Rotate(0, 0, deltaAngle);
            }
        }
    }
}