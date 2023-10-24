using App.Scripts.Game.Features.BoardState.Configs;
using App.Scripts.Game.Features.RemoveBlocks.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.BoardState.Systems {
    public class SystemBoardStateCheck : SystemBase {
        private readonly IBoardStateCheckMinPoint _minPointMarker;

        private IComponentsFilter _componentsFilter;

        public SystemBoardStateCheck(IBoardStateCheckMinPoint minPointMarker) {
            _minPointMarker = minPointMarker;
        }

        public override void OnAwake() {
            _componentsFilter = ComponentsFilter.Builder
                .With<ComponentBlock>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _componentsFilter.Apply(World)) {
                var blockView = entity.GetComponent<ComponentBlock>();
                var transform = blockView.Block.transform;
                
                if (transform.position.y > _minPointMarker.DestroyBlocksY) {
                    continue;
                }
                
                entity.AddComponent(new ComponentRemoveBlockEndOfFrame());
            }
        }
    }
}