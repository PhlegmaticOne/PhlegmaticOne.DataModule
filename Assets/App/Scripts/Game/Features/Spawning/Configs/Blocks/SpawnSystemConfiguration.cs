using System.Collections.Generic;
using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Features.Spawning.Configs.Blocks.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Features.Spawning.Configs.Blocks {
    [CreateAssetMenu(fileName = "SpawnSystemConfiguration", menuName = "Game/Spawn/Spawn System Configuration")]
    public class SpawnSystemConfiguration : SerializedScriptableObject {
        [SerializeField] private Dictionary<BlockType, FruitSpawnData> _fruitSpawnData;
        [SerializeField] private Dictionary<BlockType, ExtraBlockSpawnData> _extraBlockSpawnData;
        [SerializeField] private PackageSpawnData _packageSpawnData;

        public IDictionary<BlockType, FruitSpawnData> FruitSpawnData => _fruitSpawnData;
        public IDictionary<BlockType, ExtraBlockSpawnData> ExtraBlockSpawnData => _extraBlockSpawnData;
        public PackageSpawnData PackageSpawnData => _packageSpawnData;
    }
}