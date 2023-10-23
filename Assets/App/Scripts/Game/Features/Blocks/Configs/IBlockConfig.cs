using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Configs {
    public interface IBlockConfig {
        Sprite Sprite { get; }
        Block Prefab { get; }
        Color ParticleEffectColor { get; }
        float Radius { get; }
        int ScoreForSlicing { get; }
    }
}