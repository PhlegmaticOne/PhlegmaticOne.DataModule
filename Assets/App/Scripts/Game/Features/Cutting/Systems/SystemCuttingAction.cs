using App.Scripts.Common.Extensions;
using App.Scripts.Game.Features._Common.Services;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.Cutting.Configs;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using App.Scripts.Menu.Features.Statistics.Services;
using Assets.App.Scripts.Game.Features.Blocks.Models;

namespace App.Scripts.Game.Features.Cutting.Systems {
    public class SystemCuttingAction : SystemBase {
        private readonly CuttingConfig _config;
        private readonly ISessionService _sessionService;

        private IComponentsFilter _filter;
        private IComponentsFilter _blocksFilter;

        public SystemCuttingAction(CuttingConfig config, ISessionService sessionService)
        {
            _config = config;
            _sessionService = sessionService;
        }
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentCuttingVector>()
                .Build();

            _blocksFilter = ComponentsFilter.Builder
                .With<ComponentBlock>()
                .With<ComponentBlockCuttable>()
                .Without<ComponentTemporaryUncuttable>()
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
                var componentBlock = entity.GetComponent<ComponentBlock>();
                
                if (componentBlock.Block.IsRemote) {
                    continue;
                }
                
                var distance = (componentBlock.Block.transform.position - cuttingPoint).WithZ(0).magnitude;
                
                if (distance <= componentBlock.BlockConfig.Radius) {
                    entity.AddComponent(new ComponentBlockCut {
                        CuttingVector = componentCuttingVector.CuttingVector
                    });

                    AddCuttedBlockToStatistics(componentBlock);
                }
            }
        }

        private void AddCuttedBlockToStatistics(ComponentBlock componentBlock)
        {
            var blockType = componentBlock.BlockData.Type;
            _sessionService.AddSlice(blockType);
        }
    }
}