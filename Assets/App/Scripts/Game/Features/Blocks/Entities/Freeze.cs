using App.Scripts.Game.Features.BlocksSplit.Components;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Freezing.Components;
using App.Scripts.Game.Features.Particles.Components;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Entities {
    public class Freeze : Block {
        [SerializeField] private float _force;
        [SerializeField] private float _time;
        [SerializeField] private ParticleSystem[] _particleSystems;
        
        protected override void AddComponentsToBlockEntity(Entity entity, ComponentBlockSpawnData blockSpawnData) {
            entity.AddComponent(new ComponentBlockCuttable());
            entity.AddComponent(new ComponentGravity {
                Acceleration = blockSpawnData.Acceleration,
                Speed = blockSpawnData.Speed,
                StartSpeed = blockSpawnData.Speed,
                DeltaTimeDivider = blockSpawnData.DeltaTimeDivider
            });
            entity.AddComponent(new ComponentSpawnParticleOnCut {
                Particles = _particleSystems
            });
            entity.AddComponent(new ComponentSplitBlockOnCut {
                Sprite = BlockData.BlockConfig.Sprite
            });
            entity.AddComponent(new ComponentFreezeOnCut {
                Force = _force,
                Time = _time
            });
        }
    }
}