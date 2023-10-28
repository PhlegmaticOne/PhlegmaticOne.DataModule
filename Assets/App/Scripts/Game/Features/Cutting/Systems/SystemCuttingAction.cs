using App.Scripts.Common.Extensions;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Cutting.Configs;
using App.Scripts.Game.Features.Score.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Cutting.Systems {
    public class SystemCuttingAction : SystemBase {
        private readonly CuttingConfig _config;
        
        private IComponentsFilter _filter;
        private IComponentsFilter _blocksFilter;

        public SystemCuttingAction(CuttingConfig config) {
            _config = config;
        }
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentCuttingVector>()
                .Build();

            _blocksFilter = ComponentsFilter.Builder
                .With<ComponentBlock>()
                .With<ComponentBlockCuttable>()
                .Build();
        }

        public override void OnFixedUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var componentCuttingVector = entity.GetComponent<ComponentCuttingVector>();
                var slicingVector = componentCuttingVector.CuttingVector;
                var speed = slicingVector.magnitude / deltaTime;
                
                if (speed > _config.MinCutSpeed) {
                    CutBlocks(componentCuttingVector);
                }

                entity.RemoveComponent<ComponentCuttingVector>();
            }
        }

        private void CutBlocks(ComponentCuttingVector componentCuttingVector) {
            var cuttingPoint = componentCuttingVector.CuttingPoint;
            
            foreach (var entity in _blocksFilter.Apply(World)) {
                var blockTransform = entity.GetComponent<ComponentBlock>();
                var distance = (blockTransform.Block.transform.position - cuttingPoint).WithZ(0).magnitude;
                
                if (distance <= blockTransform.BlockConfig.Radius) {
                    entity.AddComponent(new ComponentBlockCut {
                        CuttingVector = componentCuttingVector.CuttingVector
                    });
                }
            }
        }
    }
}