using App.Scripts.Game.Features.Cutting.Configs;
using App.Scripts.Game.Features.Cutting.Factories;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Features.Cutting.Installer {
    public class CuttingInstaller : MonoInstaller {
        [SerializeField] private BladeFactoryConfig _bladeFactoryConfig;
        [SerializeField] private SplitBlocksConfig _splitBlocksConfig;
        
        public override void InstallBindings() {
            Container.Bind<IBladeFactory>().To<BladeFactory>().AsSingle();
            Container.Bind<BladeFactoryConfig>().FromInstance(_bladeFactoryConfig).AsSingle();
            Container.Bind<SplitBlocksConfig>().FromInstance(_splitBlocksConfig).AsSingle();
        }
    }
}