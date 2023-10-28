using App.Scripts.Game.Features.ScoreLabels.Views;
using UnityEngine;

namespace App.Scripts.Game.Features.ScoreLabels.Configs {
    [CreateAssetMenu(fileName = "ScoreLabelConfig", menuName = "Game/Score Label/Config")]
    public class ScoreLabelConfig : ScriptableObject {
        [SerializeField] private ScoreLabel _prefab;
        [SerializeField] private float _directionForce;
        [SerializeField] private float _showTime;

        public ScoreLabel Prefab => _prefab;
        public float ShowTime => _showTime;

        public float DirectionForce => _directionForce;
    }
}