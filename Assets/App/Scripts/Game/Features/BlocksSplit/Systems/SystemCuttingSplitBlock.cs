using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Features.BlocksSplit.Components;
using App.Scripts.Game.Features.BlocksSplit.Factories;
using App.Scripts.Game.Features.Cutting.Configs;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.Spawning.Factories;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;

namespace App.Scripts.Game.Features.BlocksSplit.Systems {
    public class SystemCuttingSplitBlock : NetworkSystemBase<ComponentSplitBlock> {
        private readonly IBlockContainer _blockContainer;
        private readonly IBlockSplitter _blockSplitter;
        private readonly IBlockFactory _blockFactory;
        private readonly SplitBlocksConfig _splitBlocksConfig;

        protected SystemCuttingSplitBlock(
            INetworkService networkService,
            IBlockContainer blockContainer,
            IBlockSplitter blockSplitter) : base(networkService) {
            _blockContainer = blockContainer;
            _blockSplitter = blockSplitter;
        }
        
        protected override IComponentsFilterBuilder SetupLocalFilter(IComponentsFilterBuilder builder) {
            return builder
                .With<ComponentBlock>()
                .With<ComponentSplitBlockOnCut>();
        }

        protected override void OnLocalUpdate(Entity entity, float deltaTime) {
            var splitBlocks = _blockSplitter.SplitBlock(new SplitBlockFactoryData {
                ComponentSplitBlock = entity.GetComponent<ComponentSplitBlock>(),
                ComponentSplitBlockOnCut = entity.GetComponent<ComponentSplitBlockOnCut>(),
                Original = entity.GetComponent<ComponentBlock>().Block
            });

            foreach (var splitBlock in splitBlocks) {
                _blockContainer.AddBlock(splitBlock);
            }
        }
    }
}