using App.Scripts.Game.Features.Bomb.Components;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using UnityEngine;

namespace App.Scripts.Game.Features.Bomb.Systems {
    public class SystemThrowBlocks : NetworkSystemBase<ComponentThrowBlocks> {
        private IComponentsFilter _blocksFilter;
        protected SystemThrowBlocks(INetworkService networkService) : base(networkService) { }

        public override void OnAwake() {
            _blocksFilter = ComponentsFilter.Builder
                .With<ComponentBlock>()
                .With<ComponentGravity>()
                .Build();
            base.OnAwake();
        }

        protected override IComponentsFilterBuilder SetupLocalFilter(IComponentsFilterBuilder builder) {
            return builder.With<ComponentThrowBlocks>();
        }

        protected override void OnLocalUpdate(Entity entity, float deltaTime) {
            var componentThrowBlocks = entity.GetComponent<ComponentThrowBlocks>();
            Explode(componentThrowBlocks);
            
            AddRemoteComponent(new ComponentThrowBlocks {
                Force = componentThrowBlocks.Force,
                Radius = componentThrowBlocks.Radius,
                PositionWorld = componentThrowBlocks.PositionWorld.InvertX()
            });
        }

        protected override void OnRemoteUpdate(Entity entity, ComponentThrowBlocks componentRemote, float deltaTime) {
            Explode(componentRemote);
        }

        private void Explode(ComponentThrowBlocks componentThrowBlocks) {
            var destroyingBlockPosition = componentThrowBlocks.PositionWorld;
            var radius = componentThrowBlocks.Radius;
            
            foreach (var entity in _blocksFilter.Apply(World)) {
                var block = entity.GetComponent<ComponentBlock>().Block;
                
                // if (block.IsRemote != componentThrowBlocks.IsRemote) {
                //     continue;
                // }
                
                var gravity = entity.GetComponent<ComponentGravity>();
                var direction = block.transform.position - destroyingBlockPosition;
                var colliderPoint = direction.magnitude;
                
                if (colliderPoint <= radius) {
                    var newExplosionSpeed = (radius - colliderPoint) / radius * componentThrowBlocks.Force;
                    var xSpeed = direction.x * newExplosionSpeed;
                    var ySpeed = direction.y * newExplosionSpeed;
                    gravity.Speed += new Vector3(xSpeed, ySpeed);
                }
            }
        }
    }
}