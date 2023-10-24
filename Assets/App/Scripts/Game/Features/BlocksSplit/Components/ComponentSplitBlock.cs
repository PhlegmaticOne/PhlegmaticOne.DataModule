using System;
using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.BlocksSplit.Components {
    public class ComponentSplitBlock : ComponentRemoteBase {
        public Guid BlockId;
        public Vector3Tiny CuttingVector;
    }
}