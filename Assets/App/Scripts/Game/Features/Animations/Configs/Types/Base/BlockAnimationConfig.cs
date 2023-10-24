using App.Scripts.Game.Features.Animations.Components.Base;
using UnityEngine;

namespace App.Scripts.Game.Features.Animations.Configs.Types.Base {
    public abstract class BlockAnimationConfig : ScriptableObject {
        public abstract IBlockAnimationComponent CreateAnimationComponent(int direction);
    }
}