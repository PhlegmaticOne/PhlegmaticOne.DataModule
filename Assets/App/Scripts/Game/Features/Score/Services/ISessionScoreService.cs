namespace App.Scripts.Game.Features.Score.Services {
    public interface ISessionScoreService {
        int MaxScore { get; }
        int CurrentScore { get; }
        int AddScore(int score);
    }
}