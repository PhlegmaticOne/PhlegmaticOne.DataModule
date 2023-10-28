using App.Scripts.Common.Extensions;
using UnityEngine;

namespace App.Scripts.Game.Features.Common {
    public class CameraProvider {
        public Camera Camera { get; }

        public CameraProvider(Camera camera) {
            Camera = camera;
        }

        public Vector3 WorldToScreen(Vector3 worldPosition) {
            return Camera.WorldToScreenPoint(worldPosition);
        }

        public Vector3 ScreenToWorld(Vector3 screenPosition) {
            return Camera.ScreenToWorldPoint(screenPosition).WithZ(Camera.nearClipPlane);
        }
    }
}