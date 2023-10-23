using App.Scripts.Game.Features.Blocks.Models;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Configs {
    public interface IBlockConfig {
        bool DestroyOnCut { get; }
        bool IsCuttable { get; }
        Sprite Sprite { get; }
        Color ParticleEffectColor { get; }
        float Radius { get; }
        int ScoreForSlicing { get; }
        ComboBehaviour ComboBehavior { get; }
        FallenBehaviour FallenBehaviour { get; }
        MagnetBehaviour MagnetBehaviour { get; }
    }
}