using UnityEngine;

namespace App.Scripts.Game.Features.Spawning.Configs {
    public class SpawnLine : MonoBehaviour {
        [SerializeField] private RectTransform _fromPoint;
        [SerializeField] private RectTransform _toPoint;

        public Vector3 FromPoint => _fromPoint.position;
        public Vector3 ToPoint => _toPoint.position;
    }
}