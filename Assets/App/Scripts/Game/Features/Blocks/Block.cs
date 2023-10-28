using System;
using App.Scripts.Game.Features.Blocks.Configs;
using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Features.Blocks.Views;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks {
    public class Block : SerializedMonoBehaviour {
        [SerializeField] private BlockView _blockView;
        
        public Entity Entity { get; private set; }
        public BlockData BlockData { get; private set; }
        public IBlockConfig Config => BlockData.BlockConfig;
        public Guid Id => BlockData.Id;
        public bool IsRemote { get; private set; }
        
        public void Initialize(Entity entity, BlockData blockData, ComponentBlockSpawnData blockSpawnData) {
            Entity = entity;
            BlockData = blockData;
            IsRemote = blockSpawnData.IsRemote;
            _blockView.SetupBlockView(blockData.BlockConfig);
            AddComponentsToBlockEntity(Entity, blockSpawnData);
        }

        protected virtual void AddComponentsToBlockEntity(Entity entity, ComponentBlockSpawnData blockSpawnData) { }
    }
}