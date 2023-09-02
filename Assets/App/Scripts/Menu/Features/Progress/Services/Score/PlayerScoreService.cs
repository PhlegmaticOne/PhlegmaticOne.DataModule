using System;
using System.Threading;
using System.Threading.Tasks;
using App.Scripts.Menu.Features.Progress.Models;
using PhlegmaticOne.DataStorage.Contracts;

namespace App.Scripts.Features.Progress.Services {
    public class PlayerScoreService : ServiceBase<PlayerProgress>, IPlayerScoreService {
        public event Action ScoreChanged;
        public int MaxScore => Model.MaxScore;

        protected override async Task OnInitializingAsync(CancellationToken ct) {
            Model = await DataStorage.ReadAsync<PlayerProgress>(ct);
            Model ??= PlayerProgress.Zero;
        }

        public async Task ChangeScoreAsync(int maxScore) {
            Model.ChangeScore(maxScore);
            await SaveModelAsync();
            OnScoreChanged();
        }

        private void OnScoreChanged() => ScoreChanged?.Invoke();
    }
}