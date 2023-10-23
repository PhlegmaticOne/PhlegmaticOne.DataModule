using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Configs {
    [CreateAssetMenu(fileName = "ExtraBlockConfig", menuName = "Game/Blocks/Extra Block Config")]
    public class ExtraBlockConfig : ScriptableObject {
        [Range(0f, 1f)]
        [SerializeField] private float _spawnInPackageProbability;
        [Range(0f, 1f)]
        [SerializeField] private float _spawnCountInPackagePercentage;

        public float SpawnInPackageProbability => _spawnInPackageProbability;
        public float SpawnCountInPackagePercentage => _spawnCountInPackagePercentage;
    }
}