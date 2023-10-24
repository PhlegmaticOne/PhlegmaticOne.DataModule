using App.Scripts.Game.Features.Particles.Factory.Data;

namespace App.Scripts.Game.Features.Particles.Factory {
    public interface IParticlesFactory {
        void PlayNewParticles(ParticlesFactoryData factoryData);
    }
}