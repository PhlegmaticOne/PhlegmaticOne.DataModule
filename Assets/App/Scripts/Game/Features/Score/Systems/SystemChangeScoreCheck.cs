using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Score.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Score.Systems {
    public class SystemChangeScoreCheck : SystemBase {
        private IComponentsFilter _filter;
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentChangeScoreOnCut>()
                .With<ComponentBlockCut>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var componentChangeScoreOnCut = entity.GetComponent<ComponentChangeScoreOnCut>();

                entity.AddComponent(new ComponentChangeScore {
                    ChangeDelta = componentChangeScoreOnCut.Score
                });
            }
        }
    }
}