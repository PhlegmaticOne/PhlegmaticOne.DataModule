using System.Threading.Tasks;

namespace App.Scripts.Shared.Progress.Services {
    public interface IPlayerService {
        Task InitializeAsync();
        int MaxScore { get; }
        string UserName { get; }
        void ChangeMaxScore(int maxScore);
        void ChangeName(string name);
    }
}