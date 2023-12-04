using App.Scripts.Shared.Progress.Services;
using PhlegmaticOne.FruitNinja.Shared;

namespace App.Scripts.Game.Modes.Base
{
    public class GameEndStateViewModel
    {
        private readonly IPlayerService _playerService;

        public GameEndStateViewModel(IPlayerService playerService) => _playerService = playerService;

        public PlayerEndGameMessage Winner { get; private set; }
        public PlayerEndGameMessage Loser { get; private set; }
        public bool IsDraw { get; set; }

        public GameEndStateViewModel SetWinner(PlayerEndGameMessage playerEndGameMessage)
        {
            Winner = playerEndGameMessage;
            return this;
        }

        public GameEndStateViewModel SetLoser(PlayerEndGameMessage playerEndGameMessage)
        {
            Loser = playerEndGameMessage;
            return this;
        }

        public void AddScoreToSelfIfWinner()
        {
            if (IsDraw || Winner.UserName == _playerService.UserName)
            {
                var score = _playerService.TotalScore;
                _playerService.ChangeTotalScore(score + Winner.Score);
            }
        }
    }
}