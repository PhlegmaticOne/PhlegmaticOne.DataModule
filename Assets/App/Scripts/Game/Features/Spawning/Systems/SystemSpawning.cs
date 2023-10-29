using App.Scripts.Game.Features.Blocks.Configs;
using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Features.Spawning.Factories;
using App.Scripts.Game.Features.Spawning.Services;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.Spawning.Systems {
    public class SystemSpawning : NetworkSystemBase<ComponentBlockSpawnData> {
        private readonly IBlockFactory _blockFactory;
        private readonly BlockConfigsProvider _blockConfigsProvider;
        private readonly IBlockContainer _blockContainer;
        private readonly ISpawnerSharedData _spawnerSharedData;

        public SystemSpawning(INetworkService networkService, 
            IBlockFactory blockFactory,
            BlockConfigsProvider blockConfigsProvider,
            IBlockContainer blockContainer,
            ISpawnerSharedData spawnerSharedData) : base(networkService) {
            _blockFactory = blockFactory;
            _blockConfigsProvider = blockConfigsProvider;
            _blockContainer = blockContainer;
            _spawnerSharedData = spawnerSharedData;
        }

        protected override void OnLocalUpdate(Entity entity, float deltaTime) {
            var componentBlockSpawnData = entity.GetComponent<ComponentBlockSpawnData>();
            componentBlockSpawnData.DeltaTimeDivider = _spawnerSharedData.Data.DeltaTimeDivider;
            SpawnBlock(componentBlockSpawnData);
            entity.RemoveEndOfFrame();
            AddRemoteComponent(ToRemote(componentBlockSpawnData));
        }

        protected override void OnRemoteUpdate(Entity entity, ComponentBlockSpawnData componentBlockRemote, float deltaTime) {
            SpawnBlock(componentBlockRemote);
        }

        private void SpawnBlock(ComponentBlockSpawnData componentBlockSpawnData) {
            var config = _blockConfigsProvider.GetConfig(componentBlockSpawnData.BlockType);
            var block = _blockFactory.CreateBlock(componentBlockSpawnData, config);
            _blockContainer.AddBlock(block);
        }

        private static ComponentBlockSpawnData ToRemote(ComponentBlockSpawnData blockSpawnData) {
            var position = blockSpawnData.Position;
            var speed = blockSpawnData.Speed;
            
            return new ComponentBlockSpawnData {
                Acceleration = blockSpawnData.Acceleration,
                Position = position.InvertX(),
                Speed = speed.InvertX(),
                BlockType = blockSpawnData.BlockType,
                BlockId = blockSpawnData.BlockId,
                AnimationType = blockSpawnData.AnimationType,
                DeltaTimeDivider = blockSpawnData.DeltaTimeDivider
            };
        }
    }
}