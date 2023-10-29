using System.Collections.Generic;
using App.Scripts.Common.Extensions;
using App.Scripts.Game.Features.FruitBasket.Components;
using App.Scripts.Game.Features.Spawning.Components;
using UnityEngine;

namespace App.Scripts.Game.Features.FruitBasket.Services {
    public class FruitBasketGenerator : IFruitBasketGenerator {
        private const float HalfCircle = 180f;
        private const float AngleOffset = 40f;
        
        public ComponentFruitBasket GenerateBasket(FruitBasketData data) {
            var result = new Queue<ComponentSpawnBlock>();
            var componentSpawnBlocksOnCut = data.ComponentFruitBasketOnCut;
            var block = data.Block;
            var componentGravity = data.ComponentGravity;
            
            var blockTypes = componentSpawnBlocksOnCut.AvailableBlocks;
            var count = GetBlocksCount(componentSpawnBlocksOnCut);
            var position = block.Block.transform.position;
            var originalAcceleration = componentGravity.Acceleration;
            var deltaAngle = CalculateDeltaAngle(count);
            var currentAngle = AngleOffset + deltaAngle;

            for (var i = 0; i < count; i++) {
                var blockType = blockTypes.GetRandomItem();
                var speed = CalculateSpeedForDirection(currentAngle, componentSpawnBlocksOnCut.Force);
                
                result.Enqueue(new ComponentSpawnBlock {
                    BlockType = blockType,
                    Acceleration = originalAcceleration,
                    Position = position,
                    Speed = speed
                });
                
                currentAngle += deltaAngle;
            }

            return new ComponentFruitBasket {
                SpawnBlocksData = result
            };
        }
        
        private static int GetBlocksCount(ComponentFruitBasketOnCut componentFruitBasketOnCut) {
            var countRange = componentFruitBasketOnCut.BlocksCountRange;
            return Random.Range(countRange.Min, countRange.Max + 1);
        }
        
        private static float CalculateDeltaAngle(int blocksCount) =>
            (HalfCircle - 2 * AngleOffset) / (blocksCount + 1);

        private static Vector3 CalculateSpeedForDirection(float angle, float explosionPower) =>
            Quaternion.Euler(0, 0, angle) * Vector3.right * explosionPower;
    }
}