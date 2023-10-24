using App.Scripts.Game.Features.Animations.Components;
using App.Scripts.Game.Features.Animations.Components.Base;
using App.Scripts.Game.Features.Animations.Configs.Types.Base;
using UnityEngine;

namespace App.Scripts.Game.Features.Animations.Configs.Types {
    [CreateAssetMenu(fileName = "BlockNoneAnimationConfig", menuName = "Game/Animations/Types/None")]
    public class BlockNoneAnimationConfig : BlockAnimationConfig {
        public override IBlockAnimationComponent CreateAnimationComponent(int direction) {
            return new ComponentNoneAnimation();
        }
    }
}