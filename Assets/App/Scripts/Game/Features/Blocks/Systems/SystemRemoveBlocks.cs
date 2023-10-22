using App.Scripts.Game.Features.Blocks.Components;
using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Systems {
    public class SystemRemoveBlocks : SystemBase {
        private readonly IBlockService _blockService;
        
        private IComponentsFilter _filter;

        public SystemRemoveBlocks(IBlockService blockService) {
            _blockService = blockService;
        }
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentRemoveBlockEndOfFrame>()
                .With<ComponentBlockView>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var blockView = entity.GetComponent<ComponentBlockView>();
                _blockService.RemoveBlock(blockView.BlockView);
                Object.Destroy(blockView.BlockView.gameObject);
                entity.AddComponent(new ComponentRemoveEntityEndOfFrame());
            }
        }
    }
}