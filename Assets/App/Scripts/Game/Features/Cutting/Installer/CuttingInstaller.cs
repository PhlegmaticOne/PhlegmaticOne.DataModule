using App.Scripts.Game.Features.Cutting.Factories;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Features.Cutting.Installer {
    public class CuttingInstaller : MonoInstaller {
        [SerializeField] private BladeFactoryConfig _bladeFactoryConfig;
        
        public override void InstallBindings() {
            Container.Bind<IBladeFactory>().To<BladeFactory>().AsSingle();
            Container.Bind<BladeFactoryConfig>().FromInstance(_bladeFactoryConfig).AsSingle();
        }
    }
}