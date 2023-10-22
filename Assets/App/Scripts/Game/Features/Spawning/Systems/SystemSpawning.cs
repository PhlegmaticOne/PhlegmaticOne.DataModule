using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Features.Spawning.Configs;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Serialization;
using Object = UnityEngine.Object;

namespace App.Scripts.Game.Features.Spawning.Systems {
    public class SystemSpawning : NetworkSystemBase<ComponentSpawnInfo> {
        private readonly SpawnerConfiguration _spawnerConfiguration;
        private readonly IBlockService _blockService;

        public SystemSpawning(SpawnerConfiguration spawnerConfiguration,
            INetworkService networkService, IBlockService blockService) : base(networkService) {
            _spawnerConfiguration = spawnerConfiguration;
            _blockService = blockService;
        }

        protected override void OnLocalUpdate(Entity entity, ComponentSpawnInfo componentRemote, float deltaTime) {
            SpawnBlock(componentRemote);
            entity.AddComponent(new ComponentRemoveEntityEndOfFrame());
            AddRemoteComponent(ToRemote(componentRemote));
        }

        protected override void OnRemoteUpdate(Entity entity, ComponentSpawnInfo componentRemote, float deltaTime) {
            SpawnBlock(componentRemote);
        }

        private void SpawnBlock(ComponentSpawnInfo componentSpawnInfo) {
            var view = Object.Instantiate(_spawnerConfiguration.Prefab, _spawnerConfiguration.SpawnTransform);
            view.transform.position = componentSpawnInfo.Position;
            
            var entity = World.AppendEntity();
            entity.AddComponent(new ComponentGravity {
                Acceleration = componentSpawnInfo.Acceleration,
                Speed = componentSpawnInfo.Speed
            });
            entity.AddComponent(new ComponentBlockView {
                BlockView = view,
                BlockId = componentSpawnInfo.BlockId
            });

            view.Entity = entity;
            _blockService.AddBlock(view);
        }

        private static ComponentSpawnInfo ToRemote(ComponentSpawnInfo spawnInfo) {
            var position = spawnInfo.Position;
            var speed = spawnInfo.Speed;
            
            return new ComponentSpawnInfo {
                Acceleration = spawnInfo.Acceleration,
                Position = new Vector3Tiny(-position.x, position.y, position.z),
                Speed = new Vector3Tiny(-speed.x, speed.y, speed.z),
                BlockType = spawnInfo.BlockType,
                BlockId = spawnInfo.BlockId,
                IsRemote = true
            };
        }
    }
}