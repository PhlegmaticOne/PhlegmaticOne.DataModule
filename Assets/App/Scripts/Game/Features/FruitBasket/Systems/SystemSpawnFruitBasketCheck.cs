using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.FruitBasket.Components;
using App.Scripts.Game.Features.FruitBasket.Services;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;

namespace App.Scripts.Game.Features.FruitBasket.Systems {
    public class SystemSpawnFruitBasketCheck : SystemBase {
        private readonly IFruitBasketGenerator _fruitBasketGenerator;
        
        private IComponentsFilter _filter;

        public SystemSpawnFruitBasketCheck(IFruitBasketGenerator fruitBasketGenerator) {
            _fruitBasketGenerator = fruitBasketGenerator;
        }
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentFruitBasketOnCut>()
                .With<ComponentBlockCut>()
                .With<ComponentGravity>()
                .With<ComponentBlock>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                var componentSpawnBlocksOnCut = entity.GetComponent<ComponentFruitBasketOnCut>();
                var componentBlock = entity.GetComponent<ComponentBlock>();
                var componentGravity = entity.GetComponent<ComponentGravity>();
                
                var componentFruitBasket = _fruitBasketGenerator.GenerateBasket(new FruitBasketData {
                    ComponentGravity = componentGravity,
                    ComponentFruitBasketOnCut = componentSpawnBlocksOnCut,
                    Block = componentBlock
                });
                
                componentFruitBasket.UncuttableTime = componentSpawnBlocksOnCut.UncuttableTime;
                World.AppendEntity().WithComponent(componentFruitBasket);
            }
        }
    }
}