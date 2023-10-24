using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Configs {
    public class BlockConfigModel : IBlockConfig {
        public Sprite Sprite { get; set; }
        public Block Prefab { get; set; }
        public Color ParticleEffectColor { get; set; }
        public float Radius { get; set; }
        public int ScoreForSlicing { get; set; }
    }
}