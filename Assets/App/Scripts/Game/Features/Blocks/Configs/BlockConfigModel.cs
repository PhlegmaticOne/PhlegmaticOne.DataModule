using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Configs {
    public class BlockConfigModel : IBlockConfig {
        public static BlockConfigModel WithNewSpriteAndPrefab(Sprite sprite, Block prefab) {
            return new BlockConfigModel {
                Sprite = sprite,
                Radius = 0,
                ParticleEffectColor = Color.clear,
                ScoreForSlicing = 0,
                Prefab = prefab
            };
        }
        
        public Sprite Sprite { get; set; }
        public Block Prefab { get; set; }
        public Color ParticleEffectColor { get; set; }
        public float Radius { get; set; }
        public int ScoreForSlicing { get; set; }
    }
}