using System.Collections.Generic;
using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Infrastructure.Ecs.Components.Base;

namespace App.Scripts.Game.Features.FruitBasket.Components {
    public class ComponentFruitBasket : IComponent {
        public Queue<ComponentSpawnBlock> SpawnBlocksData;
        public float UncuttableTime;
    }
}