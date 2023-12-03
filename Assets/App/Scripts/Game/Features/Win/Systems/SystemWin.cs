using App.Scripts.Game.Features.Score.Services;
using App.Scripts.Game.Features.Win.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using App.Scripts.Game.States;
using App.Scripts.Shared.Progress.Services;

namespace App.Scripts.Game.Features.Win.Systems {
    public class SystemWin : SystemBase {
        private readonly StateWin _stateWin;
        private readonly ISessionScoreService _sessionScoreService;
        private readonly IPlayerService _playerService;

        private IComponentsFilter _filter;

        public SystemWin(StateWin stateWin, 
            ISessionScoreService sessionScoreService,
            IPlayerService playerService) {
            _stateWin = stateWin;
            _sessionScoreService=sessionScoreService;
            _playerService=playerService;
        }
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentWin>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var component = entity.GetComponent<ComponentWin>();
                _stateWin.Enter(component);
                entity.RemoveEndOfFrame();
            }
        }

        private void AddScoreToWinner(ComponentWin componentWin)
        {
            if(_playerService.UserName == componentWin.PlayerName)
            {
                var newScore = _playerService.TotalScore + componentWin.Score;
                _playerService.ChangeTotalScore(newScore);
            }
        }
    }
}