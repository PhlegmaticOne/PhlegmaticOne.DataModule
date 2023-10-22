using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Features.Spawning.Configs;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using UnityEngine;

namespace App.Scripts.Game.Features.Spawning.Systems {
    public class SystemSpawning : SystemBase {
        private readonly SpawnerConfiguration _spawnerConfiguration;
        private readonly INetworkService _networkService;

        private IComponentsFilter _filter;

        public SystemSpawning(SpawnerConfiguration spawnerConfiguration, INetworkService networkService) {
            _spawnerConfiguration = spawnerConfiguration;
            _networkService = networkService;
        }

        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentSpawnInfo>()
                .Without<ComponentNetwork>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var componentSpawnInfo = entity.GetComponent<ComponentSpawnInfo>();
                SpawnBlock(componentSpawnInfo);
                entity.AddComponent(new ComponentRemoveEntityEndOfFrame());
                
                if (componentSpawnInfo.IsRemote) {
                    continue;
                }
                
                var remoteComponent = componentSpawnInfo.ToRemote();
                _networkService.NetworkEntity.AddComponent(remoteComponent);
            }
        }

        private void SpawnBlock(ComponentSpawnInfo componentSpawnInfo) {
            var view = Object.Instantiate(_spawnerConfiguration.Prefab, _spawnerConfiguration.SpawnTransform);
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