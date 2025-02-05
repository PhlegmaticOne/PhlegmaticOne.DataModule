﻿using System;
using App.Scripts.Game.Features.Network.Components;
using App.Scripts.Game.Infrastructure.Serialization;

namespace App.Scripts.Game.Features.Cutting.Components {
    public class ComponentBlockCut : ComponentRemoteBase {
        public Guid BlockId;
        public Vector3Tiny CuttingVector;
    }
}