using UnityEngine;

namespace App.Scripts.Game.Infrastructure.Serialization {
    public struct Vector3Tiny {
        public float x;
        public float y;
        public float z;

        public Vector3Tiny(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3 ToUnityVector() => this;

        public static implicit operator Vector3(Vector3Tiny vector3Tiny) {
            return new Vector3(vector3Tiny.x, vector3Tiny.y, vector3Tiny.z);
        }
        
        public static implicit operator Vector3Tiny(Vector3 v) {
            return new Vector3Tiny(v.x, v.y, v.z);
        }

        public override string ToString() {
            return $"x: {x} y: {y} z: {z}";
        }
    }
}