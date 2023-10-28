using App.Scripts.Game.Features.Combo.Components;
using App.Scripts.Game.Features.Combo.Services;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Combo.Systems {
    public class SystemComboShowTextCheck : SystemBase {
        private readonly IComboCounter _comboCounter;

        private IComponentsFilter _filter;

        public SystemComboShowTextCheck(IComboCounter comboCounter) {
            _comboCounter = comboCounter;
        }

        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentComboOnCut>()
                .With<ComponentBlockCut>()
                .With<ComponentBlock>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var componentBlock = entity.GetComponent<ComponentBlock>().Block;

                if (_comboCounter.ComboCount <= 1) {
                    continue;
                }
                
                entity.AddComponent(new ComponentShowComboText {
                    ComboValue = _comboCounter.ComboCount,
                    PositionWorld = componentBlock.transform.position
                });
            }
        }
    }
}