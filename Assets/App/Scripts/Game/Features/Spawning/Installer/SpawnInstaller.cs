using App.Scripts.Game.Features.Spawning.Configs.Spawners;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Features.Spawning.Installer {
    public class SpawnInstaller : MonoInstaller {
        [SerializeField] private SpawnersConfiguration _spawnersConfiguration;
        public override void InstallBindings() {
            Container.Bind<SpawnersConfiguration>()
                .FromInstance(_spawnersConfiguration)
                .AsSingle();
        }
    }
}