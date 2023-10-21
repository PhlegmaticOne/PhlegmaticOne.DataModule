using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game {
    public class Test : MonoBehaviour {
        [Button]
        private void DisplayWorldSize() {
            var t = transform as RectTransform;
            var v = new Vector3[4];
            t.GetWorldCorners(v);

            foreach (var vector3 in v) {
                Debug.Log(vector3);
            }
        }
    }
}