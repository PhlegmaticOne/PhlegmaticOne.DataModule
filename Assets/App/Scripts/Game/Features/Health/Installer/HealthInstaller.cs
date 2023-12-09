using App.Scripts.Game.Features.Health.Configs;
using App.Scripts.Game.Features.Health.Services;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Features.Health.Installer
{
    public class HealthInstaller : MonoInstaller
    {
        [SerializeField] private HealthViewsConfig _healthViewsConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<HealthViewsConfig>().FromInstance(_healthViewsConfig).AsSingle();
            Container.Bind<IHealthService>().To<HealthService>().AsSingle();
        }
    }
}