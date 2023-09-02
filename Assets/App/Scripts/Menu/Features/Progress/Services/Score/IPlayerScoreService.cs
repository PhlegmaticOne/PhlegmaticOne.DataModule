using System;
using System.Threading.Tasks;

namespace App.Scripts.Features.Progress.Services {
    public interface IPlayerScoreService {
        event Action ScoreChanged;
        int MaxScore { get; }
        Task ChangeScoreAsync(int maxScore);
    }
}