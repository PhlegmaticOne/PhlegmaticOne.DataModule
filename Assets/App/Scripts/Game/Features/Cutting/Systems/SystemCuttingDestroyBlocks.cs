using App.Scripts.Game.Features.Blocks.Components;
using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;

namespace App.Scripts.Game.Features.Cutting.Systems {
    public class SystemCuttingDestroyBlocks : NetworkSystemBase<ComponentDestroyAfterCut> {
        private readonly IBlockService _blockService;

        protected SystemCuttingDestroyBlocks(INetworkService networkService, IBlockService blockService) : 
            base(networkService) {
            _blockService = blockService;
        }
        
        protected override void OnLocalUpdate(Entity entity, ComponentDestroyAfterCut componentRemote, float deltaTime) {
            if (entity.TryGetComponent<ComponentBlock>(out var block) == false) {
                return;
            }
            
            entity.AddComponent(new ComponentRemoveBlockEndOfFrame());
            AddRemoteComponent(new ComponentDestroyAfterCut {
                IsRemote = true,
                BlockId = block.Block.BlockData.Id
            });
        }

        protected override void OnRemoteUpdate(Entity entity, ComponentDestroyAfterCut componentRemote, float deltaTime) {
            var blockView = _blockService.FindById(componentRemote.BlockId);
            blockView.Entity.AddComponent(new ComponentRemoveBlockEndOfFrame());
        }
    }
}