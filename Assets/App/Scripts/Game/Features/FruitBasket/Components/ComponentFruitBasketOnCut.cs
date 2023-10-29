using System.Collections.Generic;
using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Infrastructure.Ecs.Components.Base;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.FruitBasket.Components {
    public class ComponentFruitBasketOnCut : IComponent {
        public MinMaxRange<int> BlocksCountRange;
        public List<BlockType> AvailableBlocks;
        public float Force;
        public float UncuttableTime;
    }
}