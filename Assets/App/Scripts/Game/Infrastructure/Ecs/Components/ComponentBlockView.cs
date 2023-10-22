using System;
using App.Scripts.Game.Features.Blocks.Views;
using App.Scripts.Game.Infrastructure.Ecs.Components.Base;

namespace App.Scripts.Game.Infrastructure.Ecs.Components {
    public class ComponentBlockView : IComponent {
        public BlockView BlockView;
        public Guid BlockId;
    }
}