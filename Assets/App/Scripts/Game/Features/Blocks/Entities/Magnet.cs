using App.Scripts.Game.Features.BlocksSplit.Components;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Magnet.Components;
using App.Scripts.Game.Features.Particles.Components;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Entities {
    public class Magnet : Block {
        [SerializeField] private ParticleSystem[] _particleSystems;
        [SerializeField] private ComponentMagnetOnCut _componentMagnetOnCut;
        
        protected override void AddComponentsToBlockEntity(Entity entity, ComponentBlockSpawnData blockSpawnData) {
            entity.AddComponent(new ComponentBlockCuttable());
            entity.AddComponent(new ComponentMagnetized());
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
            entity.AddComponent(_componentMagnetOnCut);
        }
    }
}