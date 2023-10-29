using System;
using App.Scripts.Game.Features.Animations.Models;
using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.Spawning.Components {
    public class ComponentBlockSpawnData : ComponentRemoteBase {
        public Guid BlockId;
        public BlockType BlockType;
        public Vector3Tiny Speed;
        public Vector3Tiny Position;
        public Vector3Tiny Acceleration;
        public float UncuttableTime;
        public float DeltaTimeDivider;
        public BlockAnimationType AnimationType;
    }
}