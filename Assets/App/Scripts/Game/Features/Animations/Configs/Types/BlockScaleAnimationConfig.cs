using App.Scripts.Game.Features.Animations.Components;
using App.Scripts.Game.Features.Animations.Components.Base;
using App.Scripts.Game.Features.Animations.Configs.Types.Base;
using UnityEngine;

namespace App.Scripts.Game.Features.Animations.Configs.Types {
    [CreateAssetMenu(fileName = "BlockScaleAnimationConfig", menuName = "Game/Animations/Types/Scale")]
    public class BlockScaleAnimationConfig : BlockAnimationConfig {
        [SerializeField] private float _maxScale;
        [SerializeField] private BlockScaleAnimationBehavior _scaleAnimationBehavior;
        
        public override IBlockAnimationComponent CreateAnimationComponent(int direction) {
            return new ComponentScaleAnimation {
                MaxScale = _maxScale,
                ScaleAnimationBehavior = _scaleAnimationBehavior
            };
        }
    }
}