using System;
using System.Collections.Generic;
using App.Scripts.Game.Features.Blocks.Views;
using App.Scripts.Game.Infrastructure.Random;
using UnityEngine;

namespace App.Scripts.Game.Features.Spawning.Configs {
    [Serializable]
    public class SpawnerConfiguration {
        [SerializeField] private List<SpawnerInfo> _spawnerInfos;
        [SerializeField] private BlockView _prefab;
        [SerializeField] private Transform _spawnTransform;
        public BlockView Prefab => _prefab;
        public Transform SpawnTransform => _spawnTransform;

        public SpawnerInfo GetRandomInfo() {
            return _spawnerInfos.GetRandomItemBasedOnProbabilities();
        }
    }
}