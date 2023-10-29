using System;
using App.Scripts.Game.Features.Animations.Factories;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Spawning.Systems {
    public class SystemSpawnByBlockData : SystemBase {
        private readonly IBlockAnimationTypeFactory _blockAnimationTypeFactory;

        private IComponentsFilter _filter;

        public SystemSpawnByBlockData(IBlockAnimationTypeFactory blockAnimationTypeFactory) {
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
                var uncuttableTime = -1f;
                
                if (entity.TryGetComponent<ComponentTemporaryUncuttable>(out var componentTemporaryUncuttable)) {
                    uncuttableTime = componentTemporaryUncuttable.Time;
                }
                
                World.AppendEntity()
                    .WithComponent(new ComponentBlockSpawnData {
                        Acceleration = componentSpawnBlock.Acceleration,
                        Position = componentSpawnBlock.Position,
                        Speed = componentSpawnBlock.Speed,
                        BlockType = componentSpawnBlock.BlockType,
                        BlockId = Guid.NewGuid(),
                        UncuttableTime = uncuttableTime,
                        AnimationType = _blockAnimationTypeFactory.CreateBlockAnimationType()
                    });
                
                entity.RemoveEndOfFrame();
            }
        }
    }
}