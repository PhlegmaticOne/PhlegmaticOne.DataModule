using App.Scripts.Game.Features.Particles.Components;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Entities {
    public class Fruit : Block {
        [SerializeField] private ParticleSystem _juiceParticles;
        
        protected override void AddComponentsToBlockEntity(Entity entity, ComponentSpawnBlockData spawnBlockData) {
            entity.AddComponent(new ComponentSpawnParticleOnCut {
                Particles = _juiceParticles
            });
            entity.AddComponent(new ComponentGravity {
                Acceleration = spawnBlockData.Acceleration,
                Speed = spawnBlockData.Speed
            });
        }
    }
}