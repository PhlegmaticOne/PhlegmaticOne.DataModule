using UnityEngine;

namespace App.Scripts.Game.Features.Common {
    public class CameraProvider {
        public Camera Camera { get; }

        public CameraProvider(Camera camera) {
            Camera = camera;
        }
    }
}