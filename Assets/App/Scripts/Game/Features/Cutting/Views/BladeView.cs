using UnityEngine;

namespace App.Scripts.Game.Features.Cutting.Views {
    public class BladeView : MonoBehaviour {
        [SerializeField] private TrailRenderer _trailRenderer;

        public void StartSlicing(Vector3 slicePoint) {
            SliceTo(slicePoint);
            _trailRenderer.enabled = true;
            _trailRenderer.Clear();
        }

        public Vector3 SliceTo(Vector3 newPosition) {
            var direction = newPosition - transform.position;
            transform.position = newPosition;
            return direction;
        }

        public void EndSlicing() {
            _trailRenderer.enabled = false;
            _trailRenderer.Clear();
        }
    }
}