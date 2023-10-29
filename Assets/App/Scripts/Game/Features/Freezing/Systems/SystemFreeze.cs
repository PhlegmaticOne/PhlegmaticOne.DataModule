using App.Scripts.Game.Features.Freezing.Components;
using App.Scripts.Game.Features.Freezing.Configs;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Features.Spawning.Services;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.Freezing.Systems {
    public class SystemFreeze : SystemBase {
        private readonly FreezingSystemConfig _config;
        private readonly ISpawnerSharedData _spawnerSharedData;

        private IComponentsFilter _filter;
        private IComponentsFilter _gravityFilter;

        public SystemFreeze(FreezingSystemConfig config, ISpawnerSharedData spawnerSharedData) {
            _config = config;
            _spawnerSharedData = spawnerSharedData;
        }
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentFreezeActive>()
                .Build();

            _gravityFilter = ComponentsFilter.Builder
                .With<ComponentGravity>()
                .With<ComponentBlock>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            ComponentFreezeActive local = default;
            ComponentFreezeActive remote = default;
            
            foreach (var entity in _filter.Apply(World)) {
                var componentFreeze = entity.GetComponent<ComponentFreezeActive>();

                if (IsReCut(local, componentFreeze, entity) || IsReCut(remote, componentFreeze, entity)) {
                    continue;
                }

                ApplyFreezingToBlocks(componentFreeze);
                
                if (componentFreeze.IsApplied == false) {
                    ShowFreezingScreen(componentFreeze.IsRemote, componentFreeze.Time);
                    componentFreeze.IsApplied = true;
                }
                
                componentFreeze.CurrentTime += deltaTime;
                
                if (componentFreeze.CurrentTime >= componentFreeze.Time) {
                    ResetBlocksFreezing(componentFreeze);
                    entity.RemoveEndOfFrame();
                }

                local = !componentFreeze.IsRemote ? componentFreeze : local;
                remote = componentFreeze.IsRemote ? componentFreeze : remote;
            }
        }

        private bool IsReCut(ComponentFreezeActive current, ComponentFreezeActive newComponent, Entity newEntity) {
            if (current != null && newComponent.IsRemote == current.IsRemote) {
                current.CurrentTime = 0;
                newEntity.RemoveEndOfFrame();
                ContinueShowFreezingScreen(current.IsRemote);
                return true;
            }

            return false;
        }

        private void ShowFreezingScreen(bool isRemote, float time) {
            var screen = isRemote ? _config.Remote : _config.Local;
            screen.Show(time);
        }
        
        private void ContinueShowFreezingScreen(bool isRemote) {
            var screen = isRemote ? _config.Remote : _config.Local;
            screen.ContinueShow();
        }

        private void ApplyFreezingToBlocks(ComponentFreezeActive freezeActive) {
            SetDeltaTimeDivider(freezeActive.IsRemote, freezeActive.Force);
        }

        private void ResetBlocksFreezing(ComponentFreezeActive freezeActive) {
            SetDeltaTimeDivider(freezeActive.IsRemote, 1);
        }

        private void SetDeltaTimeDivider(bool isRemote, float value) {
            foreach (var entity in _gravityFilter.Apply(World)) {
                var componentBlock = entity.GetComponent<ComponentBlock>();

                if (componentBlock.Block.IsRemote != isRemote) {
                    continue;
                }
                
                var componentGravity = entity.GetComponent<ComponentGravity>();
                componentGravity.DeltaTimeDivider = value;
            }

            _spawnerSharedData.Data.DeltaTimeDivider = value;
        }
    }
}