using System;
using System.Collections.Generic;
using App.Scripts.Game.Features.Blocks.Views;
using App.Scripts.Game.Infrastructure.Random;
using UnityEngine;

namespace App.Scripts.Game.Features.Spawning.Configs.Spawners {
    [Serializable]
    public class SpawnersConfiguration {
        [SerializeField] private List<SpawnerData> _spawnerInfos;
        [SerializeField] private Block _prefab;
        [SerializeField] private Transform _spawnTransform;
        public Block Prefab => _prefab;
        public Transform SpawnTransform => _spawnTransform;

        public SpawnerData GetRandomSpawnerData() {
            return _spawnerInfos.GetRandomItemBasedOnProbabilities();
        }
    }
}