using App.Scripts.Game.Features.Blocks;
using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.Particles.Components;
using App.Scripts.Game.Features.Particles.Configs;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using UnityEngine;

namespace App.Scripts.Game.Features.Particles.Systems {
    public class SystemSpawnParticles : NetworkSystemBase<ComponentSpawnParticle> {
        private readonly ParticleSystemConfig _config;
        private readonly IBlockService _blockService;

        protected SystemSpawnParticles(INetworkService networkService, ParticleSystemConfig config,
            IBlockService blockService) :
            base(networkService) {
            _config = config;
            _blockService = blockService;
        }

        protected override void OnLocalUpdate(Entity entity, ComponentSpawnParticle componentRemote, float deltaTime) {
            if (entity.TryGetComponent<ComponentSpawnParticleOnCut>(out var spawnParticleOnCut) == false ||
                entity.TryGetComponent<ComponentBlock>(out var componentBlock) == false) {
                return;
            }

            PlayParticles(spawnParticleOnCut, componentBlock.Block);
            AddRemoteComponent(new ComponentSpawnParticle {
                BlockId = componentBlock.Block.BlockData.Id,
            });
        }

        protected override void OnRemoteUpdate(Entity entity, ComponentSpawnParticle componentRemote, float deltaTime) {
            var block = _blockService.FindById(componentRemote.BlockId);
            var spawnParticlesOfCut = block.Entity.GetComponent<ComponentSpawnParticleOnCut>();
            PlayParticles(spawnParticlesOfCut, block);
        }

        private void PlayParticles(ComponentSpawnParticleOnCut spawnParticleOnCut, Block block) {
            var particles = Object.Instantiate(spawnParticleOnCut.Particles, _config.SpawnTransform, true);
            var blockConfig = block.BlockData.BlockConfig;
            var module = particles.main;
            module.startColor = new ParticleSystem.MinMaxGradient(blockConfig.ParticleEffectColor);
            particles.transform.position = block.transform.position;
            particles.Play();
            Object.Destroy(particles.gameObject, particles.main.duration + 1);
        }
    }
}