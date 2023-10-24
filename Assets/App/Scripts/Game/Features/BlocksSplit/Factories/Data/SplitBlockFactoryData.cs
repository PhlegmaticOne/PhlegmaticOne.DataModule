using App.Scripts.Game.Features.Blocks;
using App.Scripts.Game.Features.BlocksSplit.Components;

namespace App.Scripts.Game.Features.BlocksSplit.Factories.Data {
    public class SplitBlockFactoryData {
        public Block Original { get; set; }
        public ComponentSplitBlockOnCut ComponentSplitBlockOnCut { get; set; }
        public ComponentSplitBlock ComponentSplitBlock { get; set; }
    }
}