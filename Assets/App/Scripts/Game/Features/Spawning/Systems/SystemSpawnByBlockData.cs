using System;
using App.Scripts.Game.Features.Animations.Factories;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Features.Spawning.Configs.Spawners;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using UnityEngine;

namespace App.Scripts.Game.Features.Spawning.Systems {
    public class SystemSpawnByBlockData : SystemBase {
        private readonly SpawnersConfiguration _spawnersConfiguration;
        private readonly IBlockAnimationTypeFactory _blockAnimationTypeFactory;

        private const float Gravity = 8;
        
        private IComponentsFilter _filter;

        public SystemSpawnByBlockData(
            SpawnersConfiguration spawnersConfiguration, 
            IBlockAnimationTypeFactory blockAnimationTypeFactory) {
            _spawnersConfiguration = spawnersConfiguration;
            _blockAnimationTypeFactory = blockAnimationTypeFactory;
        }
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentSpawnBlock>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var componentSpawnBlock = entity.GetComponent<ComponentSpawnBlock>();
                var spawnerData = _spawnersConfiguration.GetRandomSpawnerData();
                
                World.AppendEntity()
                    .WithComponent(new ComponentBlockSpawnData {
                        Acceleration = Gravity * Vector3.down,
                        Position = spawnerData.GetSpawnPoint(),
                        Speed = spawnerData.GetInitialSpeed(),
                        BlockType = componentSpawnBlock.BlockType,
                        BlockId = Guid.NewGuid(),
                        AnimationType = _blockAnimationTypeFactory.CreateBlockAnimationType()
                    });

                entity.AddComponent(new ComponentRemoveEntityEndOfFrame());
            }
        }
    }
}