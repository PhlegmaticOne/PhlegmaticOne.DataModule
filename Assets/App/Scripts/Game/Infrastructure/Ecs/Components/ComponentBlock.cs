using System;
using App.Scripts.Game.Features.Blocks;
using App.Scripts.Game.Features.Blocks.Configs;
using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Infrastructure.Ecs.Components.Base;
using App.Scripts.Game.Infrastructure.Ecs.Entities;

namespace App.Scripts.Game.Infrastructure.Ecs.Components {
    public class ComponentBlock : IComponent {
        public Block Block;
        public BlockData BlockData => Block.BlockData;
        public IBlockConfig BlockConfig => BlockData.BlockConfig;
        public Entity BlockEntity => Block.Entity;
        public Guid BlockId => BlockData.Id;
    }
}