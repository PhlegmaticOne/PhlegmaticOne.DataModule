using App.Scripts.Game.Features.Animations.Components;
using App.Scripts.Game.Features.Animations.Components.Base;
using App.Scripts.Game.Features.Animations.Configs.Types.Base;
using UnityEngine;

namespace App.Scripts.Game.Features.Animations.Configs.Types {
    [CreateAssetMenu(fileName = "BlockRotationAnimationConfig", menuName = "Game/Animations/Types/Rotation")]
    public class BlockRotationAnimationConfig : BlockAnimationConfig {
        [SerializeField] private float _speed;
        
        public override IBlockAnimationComponent CreateAnimationComponent(int direction) {
            return new ComponentRotationAnimation {
                Speed = _speed,
                Direction = direction
            };
        }
    }
}