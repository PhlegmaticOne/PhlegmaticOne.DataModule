using App.Scripts.Game.Blocks;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using App.Scripts.Game.Spawning.Components;
using App.Scripts.Game.Spawning.Configs;
using UnityEngine;

namespace App.Scripts.Game.Spawning.Systems {
    public class SystemSpawnByTime : SystemBase {
        private readonly SpawnerConfiguration _spawnerConfiguration;

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
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in World.GetEntities()) {
                if (!entity.HasComponent<ComponentSpawner>() ||
                    !entity.TryGetComponent<ComponentTimer>(out var componentTimer) ||
                    !componentTimer.IsEnd) {
                    continue;
                }
                
                var info = _spawnerConfiguration.GetRandomInfo();
                entity.AddComponent(new ComponentSpawnInfo {
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