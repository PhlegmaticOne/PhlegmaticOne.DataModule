using App.Scripts.Game.Features.Win.Components;
using App.Scripts.Game.Features.Win.Configs;
using App.Scripts.Game.Infrastructure.Ecs.Worlds;

namespace App.Scripts.Game.States {
    public class StateWin {
        private readonly FinalScreenConfig _finalScreenConfig;
        private readonly WorldRunner _worldRunner;

        public StateWin(FinalScreenConfig finalScreenConfig, WorldRunner worldRunner) {
            _finalScreenConfig = finalScreenConfig;
            _worldRunner = worldRunner;
        }
        
        public void Enter(ComponentWin componentWin) {
            _worldRunner.Dispose();
            _finalScreenConfig.FinalScreenView.ShowScreen(componentWin);
        }
    }
}