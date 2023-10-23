using System;
using App.Scripts.Game.Features.Blocks.Configs;
using App.Scripts.Game.Features.Blocks.Views.Components.Base;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Views.Components {
    [RequireComponent(typeof(SpriteRenderer))]
    public class BlockViewComponentShadow : MonoBehaviour, IBlockViewComponent {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Material _shadowMaterial;
        [SerializeField] private Vector2 _shadowOffset;
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _blockTransform;

        private void OnValidate() {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Setup(IBlockConfig blockConfig) {
            _spriteRenderer.sprite = blockConfig.Sprite;
            _spriteRenderer.material = _shadowMaterial;
        }
        
        private void LateUpdate() {
            UpdateShadow(_blockTransform);
        }

        private void UpdateShadow(Transform mainSpriteTransform) {
            var t = transform;
            t.position = mainSpriteTransform.position + (Vector3) _shadowOffset;
            t.localRotation = _transform.localRotation;
        }
    }
}