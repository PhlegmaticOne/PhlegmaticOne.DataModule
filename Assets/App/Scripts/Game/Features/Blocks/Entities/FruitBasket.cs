using System.Collections.Generic;
using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Features.BlocksSplit.Components;
using App.Scripts.Game.Features.Cutting.Components;
using App.Scripts.Game.Features.FruitBasket.Components;
using App.Scripts.Game.Features.Physics.Components;
using App.Scripts.Game.Features.Spawning.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Serialization;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Entities {
    public class FruitBasket : Block {
        [SerializeField] private float _force;
        [SerializeField] private List<BlockType> _availableBlocks;
        [SerializeField] private MinMaxRange<int> _blocksCountRange;
        [SerializeField] private float _uncuttableTime;
        
        protected override void AddComponentsToBlockEntity(Entity entity, ComponentBlockSpawnData blockSpawnData) {
            entity.AddComponent(new ComponentBlockCuttable());
            entity.AddComponent(new ComponentGravity {
                Acceleration = blockSpawnData.Acceleration,
                Speed = blockSpawnData.Speed,
                StartSpeed = blockSpawnData.Speed,
                DeltaTimeDivider = blockSpawnData.DeltaTimeDivider
            });
            entity.AddComponent(new ComponentFruitBasketOnCut {
                Force = _force,
                AvailableBlocks = _availableBlocks,
                BlocksCountRange = _blocksCountRange,
                UncuttableTime = _uncuttableTime
            });
            entity.AddComponent(new ComponentSplitBlockOnCut {
                Sprite = BlockData.BlockConfig.Sprite
            });
        }
    }
}