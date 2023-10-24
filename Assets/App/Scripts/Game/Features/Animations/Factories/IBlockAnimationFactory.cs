using System.Collections.Generic;
using App.Scripts.Game.Features.Animations.Components.Base;
using App.Scripts.Game.Features.Animations.Models;

namespace App.Scripts.Game.Features.Animations.Factories {
    public interface IBlockAnimationFactory {
        IEnumerable<IBlockAnimationComponent> CreateAnimationComponents(BlockAnimationType blockAnimationType, int direction);
    }
}