using UnityEngine;

namespace App.Scripts.Common.Extensions {
    public static class TransformExtensions {
        public static Vector2 GetSplitOffsetFromCenter(this Transform original, float radius, float additionalNewBlockAngle) {
            var originalTransform = original.transform;
            var halfRadius = originalTransform.localScale.x * radius / 2;
            var zRotation = (originalTransform.rotation.eulerAngles.z + additionalNewBlockAngle) * Mathf.Deg2Rad;
            var dx = halfRadius * Mathf.Cos(zRotation);
            var dy = halfRadius * Mathf.Sin(zRotation);
            return originalTransform.position + new Vector3(dx, dy);
        }

        public static T TakeTransformValues<T>(this T entity, Transform transform) where T : MonoBehaviour {
            var t = entity.transform;
            t.rotation = transform.rotation;
            t.localScale = transform.localScale;
            return entity;
        }
    }
}