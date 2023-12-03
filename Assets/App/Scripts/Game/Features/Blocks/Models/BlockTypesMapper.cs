using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Menu.Features.Statistics.Models;
using System;

namespace Assets.App.Scripts.Game.Features.Blocks.Models
{
    public static class BlockTypesMapper
    {
        public static StatisticsBlockType MapFromBlockType(BlockType type)
        {
            switch (type)
            {
                case BlockType.Mango: return StatisticsBlockType.Mango;
                case BlockType.Coconut: return StatisticsBlockType.Coconut;
                case BlockType.Lemon: return StatisticsBlockType.Lemon;
                case BlockType.Fig: return StatisticsBlockType.Fig;
                case BlockType.Pear: return StatisticsBlockType.Pear;
                case BlockType.Feijoa: return StatisticsBlockType.Feijoa;
                case BlockType.Granad: return StatisticsBlockType.Granad;
                case BlockType.Watermelon: return StatisticsBlockType.Watermelon;
                case BlockType.Bomb: return StatisticsBlockType.Bomb;
                case BlockType.Magnet: return StatisticsBlockType.Magnet;
                case BlockType.Ice: return StatisticsBlockType.Ice;
                case BlockType.FruitsBag: return StatisticsBlockType.FruitsBag;
            }

            throw new ArgumentOutOfRangeException("Unknown block type", nameof(type));
        }
    }
}
