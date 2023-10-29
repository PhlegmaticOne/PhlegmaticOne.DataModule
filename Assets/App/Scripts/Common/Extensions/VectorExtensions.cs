using UnityEngine;

namespace App.Scripts.Common.Extensions {
    public static class VectorExtensions {
        public static Vector3 WithZ(this Vector3 vector3, float z) {
            var result = vector3;
            result.z = z;
            return result;
        }
    }
}