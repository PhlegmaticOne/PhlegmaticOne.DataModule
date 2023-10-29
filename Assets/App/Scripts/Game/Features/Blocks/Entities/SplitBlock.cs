using App.Scripts.Game.Features.Magnet.Components;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;

namespace App.Scripts.Game.Features.Blocks.Entities {
    public class SplitBlock : Block {
        protected override void AddComponentsToBlockEntity(Entity entity, ComponentBlockSpawnData blockSpawnData) {
            entity.AddComponent(new ComponentMagnetized());
            entity.AddComponent(new ComponentGravity {
                Acceleration = blockSpawnData.Acceleration,
                Speed = blockSpawnData.Speed,
                StartSpeed = blockSpawnData.Speed,
                DeltaTimeDivider = blockSpawnData.DeltaTimeDivider
            });
        }
    }
}