using App.Scripts.Game.Features.Particles.Configs;
using App.Scripts.Game.Features.Particles.Factory.Data;
using UnityEngine;

namespace App.Scripts.Game.Features.Particles.Factory {
    public class ParticlesFactory : IParticlesFactory {
        private readonly ParticleSystemConfig _config;

        public ParticlesFactory(ParticleSystemConfig config) {
            _config = config;
        }
        
        public void PlayNewParticles(ParticlesFactoryData factoryData) {
            var particles = Object.Instantiate(factoryData.Particles, _config.SpawnTransform, true);
            var module = particles.main;
            module.startColor = new ParticleSystem.MinMaxGradient(factoryData.Color);
            particles.transform.position = factoryData.Position;
            particles.Play();
            Object.Destroy(particles.gameObject, particles.main.duration + 1);
        }
    }
}