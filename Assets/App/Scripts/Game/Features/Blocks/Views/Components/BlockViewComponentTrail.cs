using System;
using App.Scripts.Game.Features.Blocks.Configs;
using App.Scripts.Game.Features.Blocks.Views.Components.Base;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Views.Components {
    [RequireComponent(typeof(TrailRenderer))]
    public class BlockViewComponentTrail : MonoBehaviour, IBlockViewComponent {
        [SerializeField] private TrailRenderer _trailRenderer;

        private void OnValidate() {
            _trailRenderer = GetComponent<TrailRenderer>();
        }

        public void Setup(IBlockConfig blockConfig) {
            _trailRenderer.startColor = blockConfig.ParticleEffectColor;
        }
    }
}