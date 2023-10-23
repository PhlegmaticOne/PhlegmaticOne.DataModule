using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Configs {
    [CreateAssetMenu(fileName = "BlockConfig", menuName = "Game/Blocks/Block Config")]
    public class BlockConfigScriptableObject : ScriptableObject, IBlockConfig {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Block _prefab;
        [SerializeField] private Color _particleEffectColor;
        [SerializeField] private float _radius;
        [SerializeField] private int _scoreForSlicing;

        public Block Prefab => _prefab;
        public Sprite Sprite => _sprite;
        public Color ParticleEffectColor => _particleEffectColor;
        public float Radius => _radius;
        public int ScoreForSlicing => _scoreForSlicing;
    }
}