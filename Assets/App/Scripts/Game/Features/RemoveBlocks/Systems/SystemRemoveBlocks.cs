using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Features.RemoveBlocks.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using UnityEngine;

namespace App.Scripts.Game.Features.RemoveBlocks.Systems {
    public class SystemRemoveBlocks : SystemBase {
        private readonly IBlockContainer _blockContainer;
        
        private IComponentsFilter _filter;

        public SystemRemoveBlocks(IBlockContainer blockContainer) {
            _blockContainer = blockContainer;
        }
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentRemoveBlockEndOfFrame>()
                .With<ComponentBlock>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var blockView = entity.GetComponent<ComponentBlock>();
                _blockContainer.RemoveBlock(blockView.Block);
                Object.Destroy(blockView.Block.gameObject);
                entity.AddComponent(new ComponentRemoveEntityEndOfFrame());
            }
        }
    }
}