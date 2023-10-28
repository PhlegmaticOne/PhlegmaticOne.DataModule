using UnityEngine;

namespace App.Scripts.Game.Features.Combo.Configs {
    public class ComboFactoryConfig {
        public ComboConfig ComboConfig { get; }
        public Transform SpawnTransform { get; }

        public ComboFactoryConfig(ComboConfig comboConfig, Transform spawnTransform) {
            ComboConfig = comboConfig;
            SpawnTransform = spawnTransform;
        }
    }
}