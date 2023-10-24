using App.Scripts.Game.Features.Blocks;
using UnityEngine;

namespace App.Scripts.Game.Features.BlocksSplit.Configs {
    [CreateAssetMenu(fileName = "BlockSplitConfig", menuName = "Game/Blocks Split/Config")]
    public class BlockSplitConfig : ScriptableObject {
        [SerializeField] private float _sliceDirectionForce;
        [SerializeField] private Block _prefab;

        public Block Prefab => _prefab;
        public float SliceDirectionForce => _sliceDirectionForce;
    }
}