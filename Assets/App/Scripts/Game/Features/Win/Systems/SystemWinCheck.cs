using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.RemoveBlocks.Components;
using App.Scripts.Game.Features.Score.Services;
using App.Scripts.Game.Features.Win.Components;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using App.Scripts.Shared.Progress.Services;

namespace App.Scripts.Game.Features.Win.Systems {
    public class SystemWinCheck : SystemBase {
        private const int WinScore = 2000;
        
        private readonly ISessionScoreService _sessionScoreService;
        private readonly INetworkService _networkService;
        private readonly IBlockContainer _blockContainer;
        private readonly IPlayerService _playerService;

        public SystemWinCheck(ISessionScoreService sessionScoreService,
            INetworkService networkService,
            IBlockContainer blockContainer,
            IPlayerService playerService) {
            _sessionScoreService = sessionScoreService;
            _networkService = networkService;
            _blockContainer = blockContainer;
            _playerService=playerService;
        }

        public override void OnUpdate(float deltaTime) {
            if (_sessionScoreService.CurrentScore < WinScore) {
                return;
            }
            
            var componentWin = new ComponentWin {
                Score = _sessionScoreService.CurrentScore,
                PlayerName = _playerService.UserName
            };
            
            foreach (var block in _blockContainer) {
                block.Entity.AddComponent(new ComponentRemoveBlockEndOfFrame());
            }

            World.AppendEntity().WithComponent(componentWin);
            _networkService.NetworkEntity.AddComponent(componentWin);
        }
    }
}