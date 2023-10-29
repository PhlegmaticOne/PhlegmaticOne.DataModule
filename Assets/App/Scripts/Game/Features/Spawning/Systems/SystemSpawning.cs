using App.Scripts.Game.Features.Blocks.Configs;
using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Features.Spawning.Factories;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.Spawning.Systems {
    public class SystemSpawning : NetworkSystemBase<ComponentBlockSpawnData> {
        private readonly IBlockFactory _blockFactory;
        private readonly BlockConfigsProvider _blockConfigsProvider;
        private readonly IBlockContainer _blockContainer;

        public SystemSpawning(INetworkService networkService, 
            IBlockFactory blockFactory,
            BlockConfigsProvider blockConfigsProvider,
            IBlockContainer blockContainer) : base(networkService) {
            _blockFactory = blockFactory;
            _blockConfigsProvider = blockConfigsProvider;
            _blockContainer = blockContainer;
        }

        protected override void OnLocalUpdate(Entity entity, float deltaTime) {
            var componentBlockRemote = entity.GetComponent<ComponentBlockSpawnData>();
            SpawnBlock(componentBlockRemote);
            entity.RemoveEndOfFrame();
            AddRemoteComponent(ToRemote(componentBlockRemote));
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
                Position = new Vector3Tiny(-position.x, position.y, position.z),
                Speed = new Vector3Tiny(-speed.x, speed.y, speed.z),
                BlockType = blockSpawnData.BlockType,
                BlockId = blockSpawnData.BlockId,
                AnimationType = blockSpawnData.AnimationType
            };
        }
    }
}