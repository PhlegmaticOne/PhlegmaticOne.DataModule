using App.Scripts.Game.Infrastructure;
using App.Scripts.Game.Infrastructure.Serialization;
using UnityEngine;

namespace App.Scripts.Game.Spawning {
    public class SpawnerInfo : MonoBehaviour {
        [SerializeField] private SpawnLine _spawnLine;
        [SerializeField] private MinMaxInfo<float> _anglesRange;
        [SerializeField] private MinMaxInfo<float> _initialSpeedMultiplierRangeX;
        [SerializeField] private MinMaxInfo<float> _initialSpeedMultiplierRangeY;
        [SerializeField] private int _priority;

        public Vector3 FromPoint => _spawnLine.FromPoint.position;
        public Vector3 ToPoint => _spawnLine.ToPoint.position;
        public MinMaxInfo<float> AnglesRange => _anglesRange;
        public MinMaxInfo<float> InitialSpeedMultiplierRangeX => _initialSpeedMultiplierRangeX;
        public MinMaxInfo<float> InitialSpeedMultiplierRangeY => _initialSpeedMultiplierRangeY;
        public float Priority => _priority;
    }
}