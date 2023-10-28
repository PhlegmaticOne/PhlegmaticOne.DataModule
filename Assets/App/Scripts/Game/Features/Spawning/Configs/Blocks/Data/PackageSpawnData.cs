using System;
using App.Scripts.Game.Infrastructure.Serialization;
using UnityEngine;

namespace App.Scripts.Game.Features.Spawning.Configs.Blocks.Data {
    [Serializable]
    public struct PackageSpawnData {
        [SerializeField] private MinMaxRange<int> _blocksInPackage;
        [SerializeField] private MinMaxRange<float> _spawnBlockInPackageIntervals;
        [SerializeField] private MinMaxRange<float> _spawnPackageIntervals;
        [SerializeField] private float _initialBlockGravity;
        [SerializeField] private int _maxDifficulty;
        
        public MinMaxRange<int> BlocksInPackage => _blocksInPackage;
        public MinMaxRange<float> SpawnBlockInPackageIntervals => _spawnBlockInPackageIntervals;
        public MinMaxRange<float> SpawnPackageIntervals => _spawnPackageIntervals;
        public float InitialBlockGravity => _initialBlockGravity;
        public int MaxDifficulty => _maxDifficulty;
    }
}