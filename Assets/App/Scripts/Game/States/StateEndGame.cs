using System.Threading.Tasks;
using App.Scripts.Common.Extensions;
using App.Scripts.Game.Features._Common.Services;
using App.Scripts.Game.Features.Score.Services;
using App.Scripts.Game.Features.Win.Configs;
using App.Scripts.Game.Infrastructure.Ecs.Worlds;
using App.Scripts.Game.Infrastructure.Session;
using App.Scripts.Game.Modes.Base;
using App.Scripts.Shared.Progress.Services;
using PhlegmaticOne.FruitNinja.Shared;

namespace App.Scripts.Game.States {
    public class StateEndGame {
        private readonly FinalScreenConfig _finalScreenConfig;
        private readonly WorldRunner _worldRunner;
        private readonly IPlayerService _playerService;
        private readonly ISessionService _sessionService;
        private readonly INetworkSession _networkSession;
        private readonly IGameModeProvider _gameModeProvider;

        public StateEndGame(
            FinalScreenConfig finalScreenConfig,
            WorldRunner worldRunner,
            IPlayerService playerService,
            ISessionService sessionService,
            INetworkSession networkSession,
            IGameModeProvider gameModeProvider) {
            _finalScreenConfig = finalScreenConfig;
            _worldRunner = worldRunner;
            _playerService = playerService;
            _sessionService = sessionService;
            _networkSession = networkSession;
            _gameModeProvider = gameModeProvider;
        }
        
        public async Task EnterWin()
        {
            _worldRunner.Dispose();
            _finalScreenConfig.FinalScreenView.ShowScreenLoading();
            SendCurrentGameState(true);
            var endSyncMessage = await _networkSession.ReceiveSyncMessageAsync();
            ProcessEndSyncMessage(endSyncMessage);
        }
        
        public async Task EnterLose()
        {
            _worldRunner.Dispose();
            _finalScreenConfig.FinalScreenView.ShowScreenLoading();
            SendCurrentGameState(false);
            var endSyncMessage = await _networkSession.ReceiveSyncMessageAsync();
            ProcessEndSyncMessage(endSyncMessage);
        }

        private void SendCurrentGameState(bool isWin)
        {
            var message = new PlayerEndGameMessage
            {
                Score = _sessionService.CurrentScore,
                IsWin = isWin,
                UserName = _playerService.UserName,
                IsBreakGame = _gameModeProvider.IsBreakGame()
            };

            var bytes = message.SerializeToJsonBytes("[ENDGAME]");
            _networkSession.SendMessage(bytes);
        }

        private void ProcessEndSyncMessage(PlayersSyncMessage playersSyncMessage)
        {
            var viewModel = _gameModeProvider.BuildGameEndState(playersSyncMessage);
            viewModel.AddScoreToSelfIfWinner();
            _finalScreenConfig.FinalScreenView.ShowGameResult(viewModel);
            _networkSession.Dispose();
        }
    }
}