using App.Scripts.Game.Features.Win.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using App.Scripts.Game.States;

namespace App.Scripts.Game.Features.Win.Systems
{
    public class SystemLose : SystemBase
    {
        private readonly StateEndGame _stateEndGame;
        private IComponentsFilter _filter;

        public SystemLose(StateEndGame stateEndGame)
        {
            _stateEndGame = stateEndGame;
        }
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentInstantLose>()
                .Build();
        }
        
        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) 
            {
                if (!SystemWin.IsWin)
                {
                    _ = _stateEndGame.EnterLose();
                }
                
                entity.RemoveEndOfFrame();
            }
        }
    }
}