using System;
using System.Threading;
using System.Threading.Tasks;
using App.Scripts.Menu.Features.Progress.Models;
using PhlegmaticOne.DataStorage.Contracts;

namespace App.Scripts.Menu.Features.Progress.Services.Coins {
    public class PlayerCoinsService : ServiceBase<PlayerProgress>, IPlayerCoinsService {
        public event Action CoinsChanged;

        public int CoinsCount => Model.CoinsCount;

        protected override async Task OnInitializingAsync(CancellationToken ct) {
            Model = await DataStorage.ReadAsync<PlayerProgress>(ct);
            Model ??= PlayerProgress.Zero;
        }

        public async Task ChangeCoinsAsync(int maxScore) {
            Model.ChangeCoins(maxScore);
            await SaveModelAsync();
            OnCoinsChanged();
        }

        private void OnCoinsChanged() => CoinsChanged?.Invoke();
    }
}