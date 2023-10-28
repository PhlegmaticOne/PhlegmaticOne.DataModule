using App.Scripts.Game.Features.Combo.Configs;

namespace App.Scripts.Game.Features.Combo.Services {
    public class ComboCounter : IComboCounter {
        private readonly ComboConfig _config;

        private float _currentTime;
        private bool _isActive;

        public ComboCounter(ComboConfig config) {
            _config = config;
            ComboCount = 1;
        }

        public int ComboCount { get; private set; }

        public void OnUpdate(float deltaTime) {
            _currentTime += deltaTime;
            
            if (_currentTime >= _config.ComboMaxTime) {
                _isActive = false;
                ComboCount = 1;
            }
        }

        public int RecalculateScore(int score) {
            if (_isActive == false) {
                _isActive = true;
                _currentTime = 0;
                ComboCount = 1;
                return score;
            }

            ++ComboCount;
            return score * ComboCount;
        }
    }
}