using System.Collections.Generic;
using App.Scripts.Game.Blocks;
using App.Scripts.Game.Spawning.Configs;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Spawning.Installer {
    public class SpawnInstaller : MonoInstaller {
        [SerializeField] private List<SpawnerInfo> _spawnerInfos;
        [SerializeField] private BlockView _blockView;
        public override void InstallBindings() {
            Container.Bind<SpawnerConfiguration>()
                .FromInstance(new SpawnerConfiguration(_spawnerInfos, _blockView))
                .AsSingle();
        }
    }
}