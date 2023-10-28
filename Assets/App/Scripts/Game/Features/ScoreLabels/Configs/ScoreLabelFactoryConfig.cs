using UnityEngine;

namespace App.Scripts.Game.Features.ScoreLabels.Configs {
    public class ScoreLabelFactoryConfig {
        public ScoreLabelConfig ScoreLabelConfig { get; }
        public Transform SpawnTransform { get; }

        public ScoreLabelFactoryConfig(ScoreLabelConfig scoreLabelConfig, Transform spawnTransform) {
            SpawnTransform = spawnTransform;
            ScoreLabelConfig = scoreLabelConfig;
        }
    }
}