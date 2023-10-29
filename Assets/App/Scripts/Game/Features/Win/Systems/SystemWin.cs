using App.Scripts.Game.Features.Win.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using App.Scripts.Game.States;

namespace App.Scripts.Game.Features.Win.Systems {
    public class SystemWin : SystemBase {
        private readonly StateWin _stateWin;
        private IComponentsFilter _filter;

        public SystemWin(StateWin stateWin) {
            _stateWin = stateWin;
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
    }
}