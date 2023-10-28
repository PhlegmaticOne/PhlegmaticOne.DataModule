using App.Scripts.Game.Features.Common;
using App.Scripts.Game.Features.ScoreLabels.Components;
using App.Scripts.Game.Features.ScoreLabels.Configs;
using UnityEngine;

namespace App.Scripts.Game.Features.ScoreLabels.Factory {
    public class ScoreLabelFactory : IScoreLabelFactory {
        private readonly ScoreLabelFactoryConfig _config;
        private readonly CameraProvider _cameraProvider;

        public ScoreLabelFactory(ScoreLabelFactoryConfig config, CameraProvider cameraProvider) {
            _config = config;
            _cameraProvider = cameraProvider;
        }
        
        public void CreateLabel(ComponentScoreLabel componentScoreLabel) {
            var config = _config.ScoreLabelConfig;
            var scoreLabel = Object.Instantiate(config.Prefab, _config.SpawnTransform);
            var direction = componentScoreLabel.Direction.ToUnityVector() * config.DirectionForce;
            var screenPosition = _cameraProvider.WorldToScreen(componentScoreLabel.PositionWorld);
            scoreLabel.SetScore(componentScoreLabel.Score);
            scoreLabel.ShowAnimate(screenPosition, direction, config.ShowTime);
        }
    }
}