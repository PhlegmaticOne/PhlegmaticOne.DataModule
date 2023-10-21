using System.Collections.Generic;
using App.Scripts.Game.Blocks;
using App.Scripts.Game.Infrastructure.Random;

namespace App.Scripts.Game.Spawning.Configs {
    public class SpawnerConfiguration {
        private readonly List<SpawnerInfo> _spawnerInfos;
        public BlockView Prefab { get; }

        public SpawnerConfiguration(List<SpawnerInfo> spawnerInfos, BlockView prefab) {
            _spawnerInfos = spawnerInfos;
            Prefab = prefab;
        }

        public SpawnerInfo GetRandomInfo() {
            return _spawnerInfos.GetRandomItemBasedOnProbabilities();
        }
    }
}