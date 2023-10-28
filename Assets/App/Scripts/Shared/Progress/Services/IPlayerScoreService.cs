using System.Threading.Tasks;

namespace App.Scripts.Shared.Progress.Services {
    public interface IPlayerScoreService {
        Task InitializeAsync();
        int MaxScore { get; }
        void ChangeMaxScore(int maxScore);
    }
}