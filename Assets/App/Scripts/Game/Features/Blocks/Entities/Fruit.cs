using App.Scripts.Game.Features.BlocksSplit.Components;
using App.Scripts.Game.Features.Combo.Components;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Particles.Components;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Features.Score.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Entities {
    public class Fruit : Block {
        [SerializeField] private ParticleSystem[] _destroyParticles;
        [SerializeField] private int _scoreOnCut;
        
        protected override void AddComponentsToBlockEntity(Entity entity, ComponentBlockSpawnData blockSpawnData) {
            entity.AddComponent(new ComponentBlockCuttable());
            entity.AddComponent(new ComponentComboOnCut());
            entity.AddComponent(new ComponentChangeScoreOnCut {
                Score = _scoreOnCut
            });
            entity.AddComponent(new ComponentSpawnParticleOnCut {
                Particles = _destroyParticles
            });
            entity.AddComponent(new ComponentGravity {
                Acceleration = blockSpawnData.Acceleration,
                Speed = blockSpawnData.Speed,
                StartSpeed = blockSpawnData.Speed,
                DeltaTimeDivider = blockSpawnData.DeltaTimeDivider
            });
            entity.AddComponent(new ComponentSplitBlockOnCut {
                Sprite = BlockData.BlockConfig.Sprite
            });
        }
    }
}