using App.Scripts.Game.Features.Freezing.Configs;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Features.Freezing.Installer {
    public class FreezingInstaller : MonoInstaller {
        [SerializeField] private FreezingSystemConfig _config;
        
        public override void InstallBindings() {
            Container.Bind<FreezingSystemConfig>().FromInstance(_config).AsSingle();
        }
    }
}