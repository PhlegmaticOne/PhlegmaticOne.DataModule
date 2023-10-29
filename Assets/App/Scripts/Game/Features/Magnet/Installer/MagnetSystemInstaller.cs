using App.Scripts.Game.Features.Magnet.Configs;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Features.Magnet.Installer {
    public class MagnetSystemInstaller : MonoInstaller {
        [SerializeField] private MagnetSystemConfig _magnetSystemConfig;
        
        public override void InstallBindings() {
            Container.Bind<MagnetSystemConfig>().FromInstance(_magnetSystemConfig).AsSingle();
        }
    }
}