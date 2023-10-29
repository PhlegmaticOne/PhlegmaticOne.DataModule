using App.Scripts.Game.Features.Win.Configs;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Features.Win.Installer {
    public class FinalScreenInstaller : MonoInstaller {
        [SerializeField] private FinalScreenConfig _finalScreenConfig;
        public override void InstallBindings() {
            Container.Bind<FinalScreenConfig>().FromInstance(_finalScreenConfig).AsSingle();
        }
    }
}