using App.Scripts.Game.Features.Health.Services;
using App.Scripts.Game.Modes.Base;
using PhlegmaticOne.FruitNinja.Shared;
using Zenject;

namespace App.Scripts.Game.Modes.ByLifes
{
    public class GameModeByLifes : GameModeBase<GameDataByLifes>
    {
        private IHealthService _healthService;
        public override GameModeType GameModeType => GameModeType.ByLifes;
        public override bool IsBreakGame => true;

        [Inject]
        private void Construct(IHealthService healthService)
        {
            _healthService = healthService;
        }
        
        public override bool IsLocalCompleted()
        {
            return _healthService.CurrentHealth == 0;
        }

        public override GameEndStateViewModel BuildGameEndStateViewModel(PlayersSyncMessage playersSyncMessage)
        {
            return new GameEndStateViewModel(PlayerService).SetDefaultsFromPlayers(playersSyncMessage);
        }

        protected override void ApplyReceivedData()
        {
            _healthService.Initialize(GameDataBase.LifesCount);
        }
    }
}