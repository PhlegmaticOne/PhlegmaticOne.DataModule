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

        public void Initialize(Entity entity, BlockData blockData, ComponentSpawnBlockData spawnBlockData) {
            Entity = entity;
            BlockData = blockData;
            _blockView.SetupBlockView(blockData.BlockConfig);
            AddComponentsToBlockEntity(Entity, spawnBlockData);
        }

        protected virtual void AddComponentsToBlockEntity(Entity entity, ComponentSpawnBlockData spawnBlockData) { }
    }
}