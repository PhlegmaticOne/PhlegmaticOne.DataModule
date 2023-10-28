using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.Score.Components;
using App.Scripts.Game.Features.ScoreLabels.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.ScoreLabels.Systems {
    public class SystemScoreLabelCheck : SystemBase {
        private IComponentsFilter _filter;
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentChangeScore>()
                .With<ComponentBlockCut>()
                .With<ComponentBlock>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var changeScoreComponent = entity.GetComponent<ComponentChangeScore>();
                var blockCut = entity.GetComponent<ComponentBlockCut>();
                var block = entity.GetComponent<ComponentBlock>().Block;

                var local = new ComponentScoreLabel {
                    Score = changeScoreComponent.ChangeDelta,
                    Direction = blockCut.CuttingVector.ToUnityVector(),
                    PositionWorld = block.transform.position
                };

                World.AppendEntity().WithComponent(local);
            }
        }
    }
}