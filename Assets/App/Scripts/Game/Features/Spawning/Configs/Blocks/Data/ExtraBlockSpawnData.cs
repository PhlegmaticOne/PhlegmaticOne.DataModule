using System;
using UnityEngine;

namespace App.Scripts.Game.Features.Spawning.Configs.Blocks.Data {
    [Serializable]
    public struct ExtraBlockSpawnData {
        [Range(0f, 1f)]
        [SerializeField] private float _spawnInPackageProbability;
        [Range(0f, 1f)]
        [SerializeField] private float _spawnCountInPackagePercentage;
        
        public float SpawnInPackageProbability => _spawnInPackageProbability;
        public float SpawnCountInPackagePercentage => _spawnCountInPackagePercentage;
    }
}