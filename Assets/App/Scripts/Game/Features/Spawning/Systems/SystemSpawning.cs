using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Features.Spawning.Factories;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.Spawning.Systems {
    public class SystemSpawning : NetworkSystemBase<ComponentSpawnBlockData> {
        private readonly IBlockFactory _blockFactory;
        private readonly IBlockService _blockService;

        public SystemSpawning(INetworkService networkService, 
            IBlockFactory blockFactory,
            IBlockService blockService) : base(networkService) {
            _blockFactory = blockFactory;
            _blockService = blockService;
        }

        protected override void OnLocalUpdate(Entity entity, ComponentSpawnBlockData componentRemote, float deltaTime) {
            SpawnBlock(componentRemote);
            entity.AddComponent(new ComponentRemoveEntityEndOfFrame());
            AddRemoteComponent(ToRemote(componentRemote));
        }

        protected override void OnRemoteUpdate(Entity entity, ComponentSpawnBlockData componentRemote, float deltaTime) {
            SpawnBlock(componentRemote);
        }

        private void SpawnBlock(ComponentSpawnBlockData componentSpawnBlockData) {
            var block = _blockFactory.CreateBlock(componentSpawnBlockData);
            _blockService.AddBlock(block);
        }

        private static ComponentSpawnBlockData ToRemote(ComponentSpawnBlockData spawnBlockData) {
            var position = spawnBlockData.Position;
            var speed = spawnBlockData.Speed;
            
            return new ComponentSpawnBlockData {
                Acceleration = spawnBlockData.Acceleration,
                Position = new Vector3Tiny(-position.x, position.y, position.z),
                Speed = new Vector3Tiny(-speed.x, speed.y, speed.z),
                BlockType = spawnBlockData.BlockType,
                BlockId = spawnBlockData.BlockId,
                IsRemote = true
            };
        }
    }
}