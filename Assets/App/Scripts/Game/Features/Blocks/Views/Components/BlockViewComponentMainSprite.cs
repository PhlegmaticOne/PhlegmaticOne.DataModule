using App.Scripts.Game.Features.Blocks.Configs;
using App.Scripts.Game.Features.Blocks.Views.Components.Base;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Views.Components {
    [RequireComponent(typeof(SpriteRenderer))]
    public class BlockViewComponentMainSprite : MonoBehaviour, IBlockViewComponent {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private void OnValidate() {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Setup(IBlockConfig blockConfig) {
            _spriteRenderer.sprite = blockConfig.Sprite;
        }
    }
}