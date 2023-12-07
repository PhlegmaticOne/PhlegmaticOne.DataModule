using System;
using App.Scripts.Game.Features._Common.Services;
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
        
        private ISessionService _sessionService;

        [Inject]
        private void Construct(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        
        public override GameModeType GameModeType => GameModeType.ByScore;
        public override bool IsBreakGame => true;

        public override bool IsLocalCompleted() => _sessionService.CurrentScore >= GameDataBase.SessionScore;
        
        public override GameEndStateViewModel BuildGameEndStateViewModel(PlayersSyncMessage playersSyncMessage)
        {
            return new GameEndStateViewModel(PlayerService).SetDefaultsFromPlayers(playersSyncMessage);
        }

        protected override void ApplyReceivedData()
        {
            _scoreText.gameObject.SetActive(true);
            _scoreText.text = GameDataBase.SessionScore.ToString();
        }
    }
}