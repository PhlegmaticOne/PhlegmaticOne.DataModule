#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace App.Scripts.Common.Utils {
    public static class AssetUtils {
        public static IEnumerable<T> LoadAssets<T>(Object folder, params Object[] excludeFolders) where T : Object {
            var folderPath = AssetDatabase.GetAssetPath(folder);
            var filter = GetFilter<T>();
            var excludePaths = excludeFolders.Select(AssetDatabase.GetAssetPath).ToList();
            
            var prefabGuids = AssetDatabase.FindAssets($"t:{filter}", new [] { folderPath });
            foreach (var prefabGuid in prefabGuids) {
                var prefabPath = AssetDatabase.GUIDToAssetPath(prefabGuid);
                
                if (excludePaths.Any(x => prefabPath.Contains(x))) {
                    continue;
                }
                
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