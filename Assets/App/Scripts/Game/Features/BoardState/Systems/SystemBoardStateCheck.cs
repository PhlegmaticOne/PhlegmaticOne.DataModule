using App.Scripts.Game.Features.BoardState.Configs;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using UnityEngine;

namespace App.Scripts.Game.Features.BoardState.Systems {
    public class SystemBoardStateCheck : SystemBase {
        private readonly IBoardStateCheckMinPoint _minPointMarker;
        
        private IComponentsFilter _componentsFilter;

        public SystemBoardStateCheck(IBoardStateCheckMinPoint minPointMarker) {
            _minPointMarker = minPointMarker;
        }

        public override void OnAwake() {
            _componentsFilter = ComponentsFilter.Builder
                .With<ComponentTransform>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _componentsFilter.Apply(World)) {
                var transformComponent = entity.GetComponent<ComponentTransform>();
                var transform = transformComponent.Transform;
                
                if (transform.position.y > _minPointMarker.DestroyBlocksY) {
                    continue;
                }
                
                Object.Destroy(transform.gameObject);
                entity.AddComponent(new ComponentRemoveEntityEndOfFrame());
            }
        }
    }
}