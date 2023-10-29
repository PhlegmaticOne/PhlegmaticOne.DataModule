using System.Collections.Generic;
using System.Linq;
using App.Scripts.Game.Features.Animations.Components;
using App.Scripts.Game.Features.Animations.Systems.Scale.Policies;
using App.Scripts.Game.Features.Blocks;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using UnityEngine;

namespace App.Scripts.Game.Features.Animations.Systems.Scale {
    public class SystemDoAnimationScale : SystemBase {
        private readonly Dictionary<BlockScaleAnimationBehavior, IResolveScalePolicy> _resolveScalePolicies;
        
        private IComponentsFilter _filter;

        public SystemDoAnimationScale(IEnumerable<IResolveScalePolicy> resolveScalePolicies) {
            _resolveScalePolicies = resolveScalePolicies.ToDictionary(x => x.ScaleAnimationBehavior, x => x);
        }

        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentScaleAnimation>()
                .With<ComponentGravity>()
                .With<ComponentBlock>()
                .Build();
        }

        public override void OnFixedUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var scaleComponent = entity.GetComponent<ComponentScaleAnimation>();
                var block = entity.GetComponent<ComponentBlock>().Block;
                var policy = _resolveScalePolicies[scaleComponent.ScaleAnimationBehavior];
                var scale = GetScale(policy, block, scaleComponent);
                block.transform.localScale = block.OriginalScale * scale;
            }
        }

        private static float GetScale(IResolveScalePolicy resolveScalePolicy, Block block, ComponentScaleAnimation scaleComponent) {
            var data = resolveScalePolicy.GetScaleData(block);
            var abs = Mathf.Abs(data.CurrentValue);
            var max = Mathf.Abs(data.MaxValue);
            var clamp = Mathf.Clamp(abs, 0, max);
            return scaleComponent.MaxScale - clamp * (scaleComponent.MaxScale - 1) / max;
        }
    }
}