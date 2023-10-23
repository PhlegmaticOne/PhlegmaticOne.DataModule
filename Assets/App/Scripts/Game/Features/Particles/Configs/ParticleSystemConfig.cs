using UnityEngine;

namespace App.Scripts.Game.Features.Particles.Configs {
    public class ParticleSystemConfig : MonoBehaviour {
        [SerializeField] private Transform _spawnTransform;

        public Transform SpawnTransform => _spawnTransform;
    }
}