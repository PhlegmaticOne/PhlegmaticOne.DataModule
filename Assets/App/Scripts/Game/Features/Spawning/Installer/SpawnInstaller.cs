using App.Scripts.Game.Features.Spawning.Configs;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Features.Spawning.Installer {
    public class SpawnInstaller : MonoInstaller {
        [SerializeField] private SpawnerConfiguration _spawnerConfiguration;
        public override void InstallBindings() {
            Container.Bind<SpawnerConfiguration>()
                .FromInstance(_spawnerConfiguration)
                .AsSingle();
        }
    }
}