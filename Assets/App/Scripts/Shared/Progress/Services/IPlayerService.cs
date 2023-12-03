using System.Threading.Tasks;

namespace App.Scripts.Shared.Progress.Services {
    public interface IPlayerService {
        Task InitializeAsync();
        int TotalScore { get; }
        string UserName { get; }
        void ChangeTotalScore(int maxScore);
        void ChangeName(string name);
    }
}