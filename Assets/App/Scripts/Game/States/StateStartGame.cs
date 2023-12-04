using System.Threading.Tasks;
using App.Scripts.Game.Infrastructure.Ecs.Worlds;
using App.Scripts.Game.Infrastructure.Session;
using App.Scripts.Game.Modes.Base;
using App.Scripts.Shared.Progress.Services;

namespace App.Scripts.Game.States {
    public class StateStartGame {
        private readonly INetworkSession _networkSession;
        private readonly IPlayerService _playerScoreService;
        private readonly IGameModeProvider _gameModeProvider;
        private readonly WorldRunner _worldRunner;

        public StateStartGame(
            INetworkSession networkSession, 
            IPlayerService playerScoreService, 
            IGameModeProvider gameModeProvider,
            WorldRunner worldRunner) 
        {
            _networkSession = networkSession;
            _playerScoreService = playerScoreService;
            _gameModeProvider = gameModeProvider;
            _worldRunner = worldRunner;
        }

        public async Task Enter() {
            await _playerScoreService.InitializeAsync();
            await _networkSession.StartAsync();
            var gameData = await _networkSession.ReceiveGameDataAsync();
            _gameModeProvider.ApplyGameMode(gameData);
            _worldRunner.Run();
        }
    }
}