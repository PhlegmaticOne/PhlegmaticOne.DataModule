using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.RemoveBlocks.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;

namespace App.Scripts.Game.Features.Cutting.Systems {
    public class SystemCuttingCutBlocks : NetworkSystemBase<ComponentBlockCut> {
        private readonly IBlockContainer _blockContainer;

        protected SystemCuttingCutBlocks(INetworkService networkService, IBlockContainer blockContainer) : 
            base(networkService) {
            _blockContainer = blockContainer;
        }
        
        protected override IComponentsFilterBuilder SetupLocalFilter(IComponentsFilterBuilder builder) {
            return builder.With<ComponentBlock>();
        }

        protected override void OnLocalUpdate(Entity entity, float deltaTime) {
            var componentBlock = entity.GetComponent<ComponentBlock>();
            var componentBlockCut = entity.GetComponent<ComponentBlockCut>();
            var block = componentBlock.Block;
            
            entity.AddComponent(new ComponentRemoveBlockEndOfFrame());
            AddRemoteComponent(new ComponentBlockCut {
                IsRemote = true,
                BlockId = block.Id,
                CuttingVector = componentBlockCut.CuttingVector
            });
        }

        protected override void OnRemoteUpdate(Entity entity, ComponentBlockCut componentRemote, float deltaTime) {
            var blockView = _blockContainer.FindById(componentRemote.BlockId);
            blockView.Entity.AddComponent(new ComponentRemoveBlockEndOfFrame());
        }
    }
}