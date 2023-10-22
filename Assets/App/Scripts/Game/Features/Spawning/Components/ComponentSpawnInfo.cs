using System;
using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.Spawning.Components {
    public class ComponentSpawnInfo : ComponentRemoteBase {
        public Vector3Tiny Acceleration;
        public Vector3Tiny Speed;
        public Vector3Tiny Position;
        public BlockType BlockType;
        public Guid BlockId;
    }
}