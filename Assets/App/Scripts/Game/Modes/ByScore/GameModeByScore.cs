using System;
using App.Scripts.Game.Features.Score.Services;
using App.Scripts.Game.Modes.Base;
using PhlegmaticOne.FruitNinja.Shared;
using TMPro;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Modes.ByScore
{
    public class GameModeByScore : GameModeBase<GameDataByScore>
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        
        private ISessionScoreService _sessionScoreService;

        [Inject]
        private void Construct(ISessionScoreService sessionScoreService)
        {
            _sessionScoreService = sessionScoreService;
        }
        
        public override GameModeType GameModeType => GameModeType.ByScore;
        public override bool IsBreakGame => true;

        public override bool IsLocalCompleted() => _sessionScoreService.CurrentScore >= GameDataBase.SessionScore;
        
        public override GameEndStateViewModel BuildGameEndStateViewModel(PlayersSyncMessage playersSyncMessage)
        {
            if (playersSyncMessage.First == null || playersSyncMessage.Second == null)
            {
                return new GameEndStateViewModel(PlayerService)
                {
                    IsDraw = true
                }.SetWinner(playersSyncMessage.First ?? playersSyncMessage.Second);
            }
            
            var viewModel = new GameEndStateViewModel(PlayerService)
            {
                IsDraw = playersSyncMessage.First.Score == playersSyncMessage.Second.Score
            };

            var winner = playersSyncMessage.First.Score > playersSyncMessage.Second.Score
                ? playersSyncMessage.First
                : playersSyncMessage.Second;
            
            var loser = playersSyncMessage.First.Score < playersSyncMessage.Second.Score
                ? playersSyncMessage.First
                : playersSyncMessage.Second;

            return viewModel.SetWinner(winner).SetLoser(loser);
        }

        protected override void ApplyReceivedData()
        {
            _scoreText.gameObject.SetActive(true);
            _scoreText.text = GameDataBase.SessionScore.ToString();
        }
    }
}