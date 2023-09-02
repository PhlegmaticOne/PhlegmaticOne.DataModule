#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace App.Scripts.Common.Utils {
    public static class AssetUtils {
        public static IEnumerable<T> LoadAssets<T>(Object folder) where T : Object {
            var folderPath = AssetDatabase.GetAssetPath(folder);
            var filter = GetFilter<T>();
            var prefabGuids = AssetDatabase.FindAssets($"t:{filter}", new [] { folderPath });
            foreach (var prefabGuid in prefabGuids) {
                var prefabPath = AssetDatabase.GUIDToAssetPath(prefabGuid);
                var prefab = AssetDatabase.LoadAssetAtPath<T>(prefabPath);
                yield return prefab;
            }
        }

        private static string GetFilter<T>() {
            if (typeof(T) == typeof(GameObject)) {
                return "Prefab";
            }

            if (typeof(T) == typeof(ScriptableObject)) {
                return "ScriptableObject";
            }

            return typeof(T).Name;
        }
    }
}
#endif