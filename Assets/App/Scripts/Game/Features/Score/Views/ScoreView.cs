using System.Collections;
using TMPro;
using UnityEngine;

namespace App.Scripts.Game.Features.Score.Views {
    public class ScoreView : MonoBehaviour, IScoreView {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _maxScoreText;
        [SerializeField] private float _updateScoreDuration;
        
        private int _currentScore;
        private float _previousScore;
        private int _maxScore;
        private Coroutine _updateScoreCoroutine;

        public void Initialize(int maxScore) {
            _maxScore = maxScore;
            _maxScoreText.text = maxScore.ToString();
        }

        public void SetScoreInstant(int score) {
            _scoreText.text = score.ToString();
            _currentScore = score;
            _previousScore = score;
            UpdateMaxScore();
        }

        public void SetScoreAnimated(int score) {
            if (_updateScoreCoroutine != null) {
                StopCoroutine(_updateScoreCoroutine);
            }

            _currentScore = score;
            _updateScoreCoroutine = StartCoroutine(UpdateScore());
        }

        private IEnumerator UpdateScore() {
            var fps = 1.0f / Time.deltaTime;
            var step = (_currentScore - _previousScore) / (fps * _updateScoreDuration);
            
            while(_previousScore < _currentScore) {
                _previousScore += step;
                
                if (_previousScore > _currentScore) {
                    _previousScore = _currentScore;
                }

                _scoreText.text = ((int)_previousScore).ToString();
                UpdateMaxScore();
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }

        private void UpdateMaxScore() {
            _maxScore = (int)Mathf.Max(_maxScore, _previousScore);
            _maxScoreText.text = _maxScore.ToString();
        }
    }
}