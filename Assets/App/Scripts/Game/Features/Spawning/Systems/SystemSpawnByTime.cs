using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Features.Spawning.Configs;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using UnityEngine;

namespace App.Scripts.Game.Features.Spawning.Systems {
    public class SystemSpawnByTime : SystemBase {
        private readonly SpawnerConfiguration _spawnerConfiguration;
        private IComponentsFilter _filter;

        public SystemSpawnByTime(SpawnerConfiguration spawnerConfiguration) {
            _spawnerConfiguration = spawnerConfiguration;
        }
        
        public override void OnAwake() {
            World.CreateEntity()
                .WithComponent(new ComponentTimer {
                    CurrentTime = 0,
                    Time = 5
                })
                .WithComponent(new ComponentSpawner());

            _filter = ComponentsFilter.Builder
                .With<ComponentSpawner>()
                .With<ComponentTimer>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var componentTimer = entity.GetComponent<ComponentTimer>();

                if (!componentTimer.IsEnd) {
                    continue;
                }

                var info = _spawnerConfiguration.GetRandomInfo();
                World.AppendEntity()
                    .WithComponent(new ComponentSpawnInfo {
                        Acceleration = 8 * Vector3.down,
                        Position = info.GetSpawnPoint(),
                        Speed = info.GetInitialSpeed(),
                        BlockType = BlockType.Feijoa
                    });
                componentTimer.CurrentTime = 0;
            }
        }
    }
}