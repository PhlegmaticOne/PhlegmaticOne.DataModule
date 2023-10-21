using UnityEngine;

namespace App.Scripts.Game.Spawning {
    public class SpawnLine : MonoBehaviour {
        [SerializeField] private RectTransform _fromPoint;
        [SerializeField] private RectTransform _toPoint;

        public RectTransform FromPoint => _fromPoint;
        public RectTransform ToPoint => _toPoint;
    }
}