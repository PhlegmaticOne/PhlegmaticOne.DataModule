using App.Scripts.Game.Features.Blocks.Models;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Configs {
    [CreateAssetMenu(fileName = "BlockConfig", menuName = "Game/Blocks/Block Config")]
    public class BlockConfigScriptableObject : ScriptableObject, IBlockConfig {
        [SerializeField] private bool _destroyOnCut = true;
        [SerializeField] private bool _isCuttable = true;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Color _particleEffectColor;
        [SerializeField] private float _radius;
        [SerializeField] private int _scoreForSlicing;
        [SerializeField] private ComboBehaviour _comboBehavior;
        [SerializeField] private FallenBehaviour _fallenBehaviour;
        [SerializeField] private MagnetBehaviour _magnetBehaviour;
        
        public bool DestroyOnCut => _destroyOnCut;
        public bool IsCuttable => _isCuttable;
        public Sprite Sprite => _sprite;
        public Color ParticleEffectColor => _particleEffectColor;
        public float Radius => _radius;
        public int ScoreForSlicing => _scoreForSlicing;
        public ComboBehaviour ComboBehavior => _comboBehavior;
        public FallenBehaviour FallenBehaviour => _fallenBehaviour;
        public MagnetBehaviour MagnetBehaviour => _magnetBehaviour;
    }
}