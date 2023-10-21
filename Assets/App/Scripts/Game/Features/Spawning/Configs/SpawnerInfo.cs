using App.Scripts.Game.Infrastructure.Random;
using App.Scripts.Game.Infrastructure.Serialization;
using UnityEngine;

namespace App.Scripts.Game.Features.Spawning.Configs {
    public class SpawnerInfo : MonoBehaviour, IPrioritized {
        [SerializeField] private SpawnLine _spawnLine;
        [SerializeField] private MinMaxInfo<float> _anglesRange;
        [SerializeField] private MinMaxInfo<float> _initialSpeedMultiplierRangeX;
        [SerializeField] private MinMaxInfo<float> _initialSpeedMultiplierRangeY;
        [SerializeField] private int _priority;
        public float Priority => _priority;

        public Vector3 GetInitialSpeed() {
            return IncreaseInitialSpeed(GetSpeedDirection());
        }

        public Vector3 GetSpawnPoint() {
            var randomNumber = Random.Range(0, 1f);
            return (1 - randomNumber) * _spawnLine.FromPoint + randomNumber * _spawnLine.ToPoint;
        }
        
        private Vector3 GetSpeedDirection() {
            var angle = Random.Range(_anglesRange.Min, _anglesRange.Max);
            var normal = (_spawnLine.ToPoint - _spawnLine.FromPoint).normalized;
            return Quaternion.Euler(0, 0, angle) * normal;
        }

        private Vector3 IncreaseInitialSpeed(Vector3 speedDirection) {
            var randomIncreaseX = Random.Range(_initialSpeedMultiplierRangeX.Min, _initialSpeedMultiplierRangeX.Max);
            var randomIncreaseY = Random.Range(_initialSpeedMultiplierRangeY.Min, _initialSpeedMultiplierRangeY.Max);
            return new Vector3(speedDirection.x * randomIncreaseX, speedDirection.y * randomIncreaseY);
        }
    }
}