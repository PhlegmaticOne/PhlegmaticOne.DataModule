using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Cutting.Systems {
    public class SystemTemporaryUncuttableUpdate : SystemBase {
        private IComponentsFilter _filter;
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentTemporaryUncuttable>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var component = entity.GetComponent<ComponentTemporaryUncuttable>();
                component.CurrentTime += deltaTime;

                if (component.CurrentTime >= component.Time) {
                    entity.RemoveComponent<ComponentTemporaryUncuttable>();
                }
            }
        }
    }
}