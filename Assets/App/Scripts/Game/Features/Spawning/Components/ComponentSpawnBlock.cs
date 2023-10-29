using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Infrastructure.Ecs.Components.Base;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.Spawning.Components {
    public class ComponentSpawnBlock : IComponent {
        public BlockType BlockType;
        public Vector3Tiny Speed;
        public Vector3Tiny Position;
        public Vector3Tiny Acceleration;
    }
}