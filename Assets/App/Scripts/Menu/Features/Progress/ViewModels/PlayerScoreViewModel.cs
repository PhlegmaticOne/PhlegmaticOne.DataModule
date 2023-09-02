using System.Collections.Generic;
using System.Threading.Tasks;
using App.Scripts.Features.Progress.Services;
using PhlegmaticOne.ViewModels.Contracts;
using PhlegmaticOne.ViewModels.Properties;

namespace App.Scripts.Menu.Features.Progress.ViewModels {
    public class PlayerScoreViewModel : BaseViewModel {
        private readonly IPlayerScoreService _playerScoreService;

        public PlayerScoreViewModel(IPlayerScoreService playerScoreService) {
            _playerScoreService = playerScoreService;
            _playerScoreService.ScoreChanged += UpdateScore;
            MaxScore = new ReactiveProperty<int>();
        }

        public override Task InitializeAsync() {
            UpdateScore();
            return Task.CompletedTask;
        }

        public ReactiveProperty<int> MaxScore { get; }

        protected override IEnumerable<IReactiveProperty> ReactiveProperties() {
            yield return MaxScore;
        }

        protected override void OnDisposing() {
            _playerScoreService.ScoreChanged -= UpdateScore;
        }

        private void UpdateScore() => MaxScore.Value = _playerScoreService.MaxScore;
    }
}