namespace App.Scripts.Game.Features.Score.Services
{
    public class SessionScoreService : ISessionScoreService {
        private int _sessionScore;
        
        public int CurrentScore => _sessionScore;

        public int AddScore(int score) {
            _sessionScore += score;
            return _sessionScore;
        }
    }
}