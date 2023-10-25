using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.Particles.Components;
using App.Scripts.Game.Features.Particles.Factory;
using App.Scripts.Game.Features.Particles.Factory.Data;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;

namespace App.Scripts.Game.Features.Particles.Systems {
    public class SystemSpawnParticles : NetworkSystemBase<ComponentSpawnParticle> {
        private readonly IParticlesFactory _particlesFactory;
        private readonly IBlockContainer _blockContainer;

        protected SystemSpawnParticles(INetworkService networkService, IParticlesFactory particlesFactory,
            IBlockContainer blockContainer) :
            base(networkService) {
            _particlesFactory = particlesFactory;
            _blockContainer = blockContainer;
        }

        protected override IComponentsFilterBuilder SetupLocalFilter(IComponentsFilterBuilder builder) {
            return builder
                .With<ComponentSpawnParticleOnCut>()
                .With<ComponentBlock>();
        }

        protected override void OnLocalUpdate(Entity entity, float deltaTime) {
            var componentSpawnParticleOnCut = entity.GetComponent<ComponentSpawnParticleOnCut>();
            var componentBlock = entity.GetComponent<ComponentBlock>();

            foreach (var particleSystem in componentSpawnParticleOnCut.Particles) {
                _particlesFactory.PlayNewParticles(new ParticlesFactoryData {
                    Particles = particleSystem,
                    Color = componentBlock.BlockConfig.ParticleEffectColor,
                    Position = componentBlock.Block.transform.position
                });
                AddRemoteComponent(new ComponentSpawnParticle {
                    BlockId = componentBlock.BlockId,
                });
            }
        }

        protected override void OnRemoteUpdate(Entity entity, ComponentSpawnParticle componentRemote, float deltaTime) {
            var block = _blockContainer.FindById(componentRemote.BlockId);
            var spawnParticlesOfCut = block.Entity.GetComponent<ComponentSpawnParticleOnCut>();
            
            foreach (var particleSystem in spawnParticlesOfCut.Particles) {
                _particlesFactory.PlayNewParticles(new ParticlesFactoryData {
                    Particles = particleSystem,
                    Color = block.Config.ParticleEffectColor,
                    Position = block.transform.position
                });
            }
        }
    }
}