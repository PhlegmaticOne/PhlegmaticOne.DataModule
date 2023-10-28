using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Infrastructure.Ecs.Components.Base;

namespace App.Scripts.Game.Features.Spawning.Components {
    public class ComponentSpawnBlock : IComponent {
        public BlockType BlockType;
    }
}