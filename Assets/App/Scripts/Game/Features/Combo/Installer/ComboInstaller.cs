using App.Scripts.Game.Features.Combo.Configs;
using App.Scripts.Game.Features.Combo.Factory;
using App.Scripts.Game.Features.Combo.Services;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Features.Combo.Installer {
    public class ComboInstaller : MonoInstaller {
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private ComboConfig _config;
        
        public override void InstallBindings() {
            Container.Bind<IComboCounter>().To<ComboCounter>().AsSingle();

            Container.Bind<ComboFactoryConfig>()
                .FromInstance(new ComboFactoryConfig(_config, _spawnTransform))
                .AsSingle();

            Container.Bind<IComboTextFactory>().To<ComboTextFactory>().AsSingle();
        }
    }
}