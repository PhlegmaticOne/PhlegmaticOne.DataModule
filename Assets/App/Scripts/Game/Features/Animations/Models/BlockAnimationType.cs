using System;

namespace App.Scripts.Game.Features.Animations.Models {
    [Flags]
    public enum BlockAnimationType {
        None = 0,
        Rotation = 1 << 0,
        Scale = 1 << 1
    }
}