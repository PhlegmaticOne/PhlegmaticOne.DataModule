using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using UnityEngine;

namespace App.Scripts.Game.BlocksState {
    public class SystemBlocksStateCheck : SystemBase {
        public override void OnUpdate(float deltaTime) {
            foreach (var entity in World.GetEntities()) {
                if (!entity.TryGetComponent<ComponentTransform>(out var transformComponent)) {
                    continue;
                }

                if (transformComponent.Transform.position.y < -10) {
                    Object.Destroy(transformComponent.Transform.gameObject);
                    entity.AddComponent(new ComponentRemoveEntityEndOfFrame());
                }
            }
        }
    }
}