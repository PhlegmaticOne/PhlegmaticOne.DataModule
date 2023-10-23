using System;
using App.Scripts.Game.Infrastructure.Random;
using UnityEngine;

namespace App.Scripts.Game.Features.Spawning.Configs.Blocks.Data {
    [Serializable]
    public struct FruitSpawnData : IPrioritized {
        [SerializeField] private float _priority;
        public float Priority => _priority;
    }
}