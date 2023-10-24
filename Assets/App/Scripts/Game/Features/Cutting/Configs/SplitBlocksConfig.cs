using App.Scripts.Game.Features.Blocks;
using UnityEngine;

namespace App.Scripts.Game.Features.Cutting.Configs {
    public class SplitBlocksConfig : MonoBehaviour {
        [SerializeField] private Block _prefab;

        public Block Prefab => _prefab;
    }
}