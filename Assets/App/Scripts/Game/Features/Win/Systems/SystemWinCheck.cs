using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.RemoveBlocks.Components;
using App.Scripts.Game.Features.Score.Services;
using App.Scripts.Game.Features.Win.Components;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using App.Scripts.Game.Modes.Base;
using App.Scripts.Shared.Progress.Services;

namespace App.Scripts.Game.Features.Win.Systems {
    public class SystemWinCheck : SystemBase {
        private readonly IBlockContainer _blockContainer;
        private readonly IGameModeProvider _gameModeProvider;

        public SystemWinCheck(IBlockContainer blockContainer, IGameModeProvider gameModeProvider) {
            _blockContainer = blockContainer;
            _gameModeProvider = gameModeProvider;
        }

        public override void OnUpdate(float deltaTime) {
            if (_gameModeProvider.IsCurrentCompleted() == false) {
                return;
            }

            foreach (var block in _blockContainer) {
                block.Entity.AddComponent(new ComponentRemoveBlockEndOfFrame());
            }

            World.AppendEntity().WithComponent(new ComponentLocalWin());
        }
    }
}