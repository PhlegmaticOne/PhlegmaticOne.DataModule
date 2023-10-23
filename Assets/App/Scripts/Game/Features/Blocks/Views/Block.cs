using System;
using App.Scripts.Game.Features.Blocks.Components;
using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Views {
    public class Block : MonoBehaviour {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private ShadowEffect _shadowEffect;
        
        public Entity Entity { get; set; }
        
        public BlockData BlockData { get; set; }

        public void SetSprite(Sprite sprite) {
            _spriteRenderer.sprite = sprite;
            _shadowEffect.SetShadowForSprite(sprite);
        }

        private void LateUpdate() {
            _shadowEffect.UpdateShadow(transform);
        }

        [Button]
        private void UpdateShadow() {
            _shadowEffect.SetShadowForSprite(_spriteRenderer.sprite);
        }
    }
}