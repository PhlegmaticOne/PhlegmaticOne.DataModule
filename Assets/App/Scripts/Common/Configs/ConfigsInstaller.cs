using System.Collections.Generic;
using App.Scripts.Common.Utils;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace App.Scripts.Common.Configs {
    [CreateAssetMenu(fileName = "ConfigsInstaller", menuName = "Configs/Config Installer")]
    public class ConfigsInstaller : ScriptableObjectInstaller {
        [SerializeField] private List<ScriptableObject> _configs;
        [SerializeField] private Object _folder;

        public override void InstallBindings() => BindConfigs(_configs);

        private void BindConfigs(IEnumerable<ScriptableObject> configs) {
            foreach (var config in configs) {
                var type = config.GetType();
                Container.Bind(type).FromInstance(config).AsSingle();
            }
        }

        #if UNITY_EDITOR
            [Button]
            private void UpdateConfigs() {
                _configs.Clear();
                foreach (var scriptableObject in AssetUtils.LoadAssets<ScriptableObject>(_folder)) {
                    if (scriptableObject == this) {
                        continue;
                    }
                    
                    _configs.Add(scriptableObject);
                }
            }
        #endif
    }
}