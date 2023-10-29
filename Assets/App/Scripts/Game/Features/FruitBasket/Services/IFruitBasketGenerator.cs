using System.Collections.Generic;
using App.Scripts.Game.Features.FruitBasket.Components;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components;

namespace App.Scripts.Game.Features.FruitBasket.Services {
    public class FruitBasketData {
        public ComponentFruitBasketOnCut ComponentFruitBasketOnCut { get; set; }
        public ComponentGravity ComponentGravity { get; set; }
        public ComponentBlock Block { get; set; }
    }
    
    public interface IFruitBasketGenerator {
        ComponentFruitBasket GenerateBasket(FruitBasketData data);
    }
}