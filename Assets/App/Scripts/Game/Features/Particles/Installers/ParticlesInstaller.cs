using App.Scripts.Game.Features.Particles.Configs;
using App.Scripts.Game.Features.Particles.Factory;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Features.Particles.Installers {
    public class ParticlesInstaller : MonoInstaller {
        [SerializeField] private ParticleSystemConfig _particleSystemConfig;
        
        public override void InstallBindings() {
            Container.Bind<ParticleSystemConfig>().FromInstance(_particleSystemConfig).AsSingle();
            Container.Bind<IParticlesFactory>().To<ParticlesFactory>().AsSingle();
        }
    }
}