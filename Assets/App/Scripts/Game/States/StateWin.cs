using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Features.RemoveBlocks.Components;
using App.Scripts.Game.Features.Win.Components;
using App.Scripts.Game.Features.Win.Configs;
using App.Scripts.Game.Infrastructure.Ecs.Worlds;
using App.Scripts.Game.Infrastructure.Input;

namespace App.Scripts.Game.States {
    public class StateWin {
        private readonly IBlockContainer _blockContainer;
        private readonly FinalScreenConfig _finalScreenConfig;
        private readonly WorldRunner _worldRunner;

        public StateWin(IBlockContainer blockContainer, 
            FinalScreenConfig finalScreenConfig,
            WorldRunner worldRunner) {
            _blockContainer = blockContainer;
            _finalScreenConfig = finalScreenConfig;
            _worldRunner = worldRunner;
        }
        
        public void Enter(ComponentWin componentWin) {
            _worldRunner.Dispose();
            _finalScreenConfig.FinalScreenView.ShowScreen(componentWin);
        }
    }
}