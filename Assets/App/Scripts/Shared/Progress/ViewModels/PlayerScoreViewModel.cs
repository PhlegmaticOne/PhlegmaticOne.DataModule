using System.Collections.Generic;
using System.Threading.Tasks;
using App.Scripts.Shared.Progress.Services;
using PhlegmaticOne.ViewModels.Contracts;
using PhlegmaticOne.ViewModels.Properties;

namespace App.Scripts.Menu.Features.Progress.ViewModels {
    public class PlayerScoreViewModel : BaseViewModel {
        private readonly IPlayerService _playerScoreService;

        public PlayerScoreViewModel(IPlayerService playerScoreService) {
            _playerScoreService = playerScoreService;
            MaxScore = new ReactiveProperty<int>();
        }

        public override async Task InitializeAsync() {
            await _playerScoreService.InitializeAsync();
            UpdateScore();
        }

        public ReactiveProperty<int> MaxScore { get; }

        protected override IEnumerable<IReactiveProperty> ReactiveProperties() {
            yield return MaxScore;
        }

        private void UpdateScore() => MaxScore.Value = _playerScoreService.MaxScore;
    }
}