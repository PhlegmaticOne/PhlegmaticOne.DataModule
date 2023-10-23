using App.Scripts.Game.Features.Blocks.Configs;

namespace App.Scripts.Game.Features.Blocks.Views.Components.Base {
    public interface IBlockViewComponent {
        void Setup(IBlockConfig blockConfig);
    }
}