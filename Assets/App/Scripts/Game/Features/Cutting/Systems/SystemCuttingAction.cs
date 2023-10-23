using App.Scripts.Common.Extensions;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using UnityEngine;

namespace App.Scripts.Game.Features.Cutting.Systems {
    public class SystemCuttingAction : SystemBase {
        private const int MinSpeedToSlice = 20;
        
        private IComponentsFilter _filter;
        private IComponentsFilter _blocksFilter;

        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentCuttingVector>()
                .Build();

            _blocksFilter = ComponentsFilter.Builder
                .With<ComponentBlock>()
                .Build();
        }

        public override void OnFixedUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var componentCuttingVector = entity.GetComponent<ComponentCuttingVector>();
                var slicingVector = componentCuttingVector.CuttingVector;
                var speed = slicingVector.magnitude / deltaTime;
                
                if (speed > MinSpeedToSlice) {
                    CutBlocks(componentCuttingVector.CuttingPoint);
                }

                entity.RemoveComponent<ComponentCuttingVector>();
            }
        }

        private void CutBlocks(Vector3 cuttingPoint) {
            foreach (var entity in _blocksFilter.Apply(World)) {
                var blockTransform = entity.GetComponent<ComponentBlock>();
                var distance = (blockTransform.Block.transform.position - cuttingPoint).WithZ(0).magnitude;
                
                if (distance <= 1.4f) {
                    entity.AddComponent(new ComponentBlockCut());
                }
            }
        }
    }
}