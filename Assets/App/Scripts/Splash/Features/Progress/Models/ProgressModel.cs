using System;

namespace App.Scripts.Splash.Features.Progress.Models {
    public readonly struct ProgressModel {
        private ProgressModel(float normalizedProgress) => NormalizedProgress = normalizedProgress;

        public float NormalizedProgress { get; }
        public float Progress => NormalizedProgress * 100;
        public int ProgressInt => (int)Progress;

        public static ProgressModel FromNormalizedProgress(float normalizedProgress) {
            if (normalizedProgress < 0 || normalizedProgress > 1) {
                throw new ArgumentException("Passed progress is not normalized: [0, 1]", nameof(normalizedProgress));
            }

            return new ProgressModel(normalizedProgress);
        }

        public static ProgressModel FromProgress(int progress) {
            if (progress < 0 || progress > 100) {
                throw new ArgumentException("Passed progress is not in progress range: [0, 100]", nameof(progress));
            }

            var normalizedProgress = progress / 100f;
            return FromNormalizedProgress(normalizedProgress);
        }
    }
}