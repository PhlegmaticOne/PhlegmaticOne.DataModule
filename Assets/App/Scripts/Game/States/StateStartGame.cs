using System.Threading.Tasks;
using App.Scripts.Game.Infrastructure.Ecs.Worlds;
using App.Scripts.Game.Infrastructure.Session;
using App.Scripts.Shared.Progress.Services;

namespace App.Scripts.Game.States {
    public class StateStartGame {
        private readonly INetworkSession _networkSession;
        private readonly IPlayerScoreService _playerScoreService;
        private readonly WorldRunner _worldRunner;

        public StateStartGame(INetworkSession networkSession, 
            IPlayerScoreService playerScoreService, 
            WorldRunner worldRunner) {
            _networkSession = networkSession;
            _playerScoreService = playerScoreService;
            _worldRunner = worldRunner;
        }

        public async Task Enter() {
            await _playerScoreService.InitializeAsync();
            await _networkSession.StartAsync();
            _worldRunner.Run();
        }
    }
}