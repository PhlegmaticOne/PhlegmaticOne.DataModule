using App.Scripts.Game.Features.Combo.Services;
using App.Scripts.Game.Features.Score.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Combo.Systems {
    public class SystemComboCheck : SystemBase {
        private readonly IComboCounter _comboCounter;
        
        private IComponentsFilter _filter;

        public SystemComboCheck(IComboCounter comboCounter) {
            _comboCounter = comboCounter;
        }
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentChangeScore>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            _comboCounter.OnUpdate(deltaTime);
            
            foreach (var entity in _filter.Apply(World)) {
                var componentScore = entity.GetComponent<ComponentChangeScore>();
                
                if (componentScore.IsRemote) {
                    continue;
                }
                
                componentScore.ChangeDelta = _comboCounter.RecalculateScore(componentScore.ChangeDelta);
            }
        }
    }
}