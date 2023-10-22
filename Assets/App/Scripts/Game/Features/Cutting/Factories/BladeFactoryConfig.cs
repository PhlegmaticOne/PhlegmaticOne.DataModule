using System;
using App.Scripts.Game.Features.Cutting.Views;
using UnityEngine;

namespace App.Scripts.Game.Features.Cutting.Factories {
    [Serializable]
    public class BladeFactoryConfig {
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private BladeSpawnPointMarker _remoteBladePoint;
        [SerializeField] private BladeSpawnPointMarker _localBladePoint;
        [SerializeField] private BladeView _prefab;

        public Transform SpawnTransform => _spawnTransform;
        public Vector3 RemoteBladePoint => _remoteBladePoint.Position;
        public Vector3 LocalBladePoint => _localBladePoint.Position;
        public BladeView BladeView => _prefab;
    }
}