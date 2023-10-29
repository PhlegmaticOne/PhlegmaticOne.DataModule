using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.FruitBasket.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.FruitBasket.Systems {
    public class SystemSpawnFruitBasket : SystemBase {
        private IComponentsFilter _filter;

        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentFruitBasket>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var componentFruitBasket = entity.GetComponent<ComponentFruitBasket>();
                var spawnInfo = componentFruitBasket.SpawnBlocksData.Dequeue();
                PendFruitForSpawn(spawnInfo, componentFruitBasket.UncuttableTime);

                if (componentFruitBasket.SpawnBlocksData.Count == 0) {
                    entity.RemoveEndOfFrame();
                }
            }
        }

        private void PendFruitForSpawn(ComponentSpawnBlock componentSpawnBlock, float uncuttableTime) {
            World.AppendEntity()
                .WithComponent(componentSpawnBlock)
                .WithComponent(new ComponentTemporaryUncuttable {
                    Time = uncuttableTime
                });
        }
    }
}