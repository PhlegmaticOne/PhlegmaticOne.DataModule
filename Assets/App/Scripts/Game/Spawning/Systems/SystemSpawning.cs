using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components.Base;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using App.Scripts.Game.Network;
using App.Scripts.Game.Physics;
using App.Scripts.Game.Spawning.Components;
using App.Scripts.Game.Spawning.Configs;
using UnityEngine;

namespace App.Scripts.Game.Spawning.Systems {
    public class SystemSpawning : SystemBase {
        private readonly SpawnerConfiguration _spawnerConfiguration;
        private readonly NetworkService _networkService;

        public SystemSpawning(SpawnerConfiguration spawnerConfiguration, NetworkService networkService) {
            _spawnerConfiguration = spawnerConfiguration;
            _networkService = networkService;
        }
        
        public override void OnUpdate(float deltaTime) {
            foreach (var entity in World.GetEntities()) {
                if (entity.HasComponent<ComponentNetwork>() ||
                    entity.TryGetComponent<ComponentSpawnInfo>(out var componentSpawnInfo) == false) {
                    continue;
                }
                
                SpawnBlock(componentSpawnInfo);
                entity.RemoveComponent<ComponentSpawnInfo>();
                if (!componentSpawnInfo.IsRemote) {
                    _networkService.NetworkEntity.AddComponent(componentSpawnInfo.AsRemote());
                }
            }
        }

        private void SpawnBlock(ComponentSpawnInfo componentSpawnInfo) {
            var view = Object.Instantiate(_spawnerConfiguration.Prefab);
            view.transform.position = componentSpawnInfo.Position;
            
            var entity = World.AppendEntity();
            entity.AddComponent(new ComponentGravity {
                Acceleration = componentSpawnInfo.Acceleration,
                Speed = componentSpawnInfo.Speed
            });
            entity.AddComponent(new ComponentTransform {
                Transform = view.transform
            });
        }
    }
}