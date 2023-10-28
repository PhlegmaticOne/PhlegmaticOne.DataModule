using System.Globalization;
using App.Scripts.Game.Features.Blocks.Configs;
using App.Scripts.Game.Features.Blocks.Views.Components.Base;
using UnityEngine;

namespace App.Scripts.Game.Features.Blocks.Views.Components {
    [RequireComponent(typeof(TrailRenderer))]
    public class BlockViewComponentTrail : MonoBehaviour, IBlockViewComponent {
        [SerializeField] private TrailRenderer _trailRenderer;
        [SerializeField] private int _effect;

        private void OnValidate() {
            _trailRenderer = GetComponent<TrailRenderer>();
        }

        public void Setup(IBlockConfig blockConfig) {
            _trailRenderer.startColor = blockConfig.ParticleEffectColor;
            _trailRenderer.endColor = LightenDarkenColor(blockConfig.ParticleEffectColor, _effect);
        }

        private static Color LightenDarkenColor(Color col, int amt) {
            var stringRGB = ColorUtility.ToHtmlStringRGB(col);
            var num = int.Parse(stringRGB, NumberStyles.HexNumber);
            var r = (num >> 16) + amt;
            var b = ((num >> 8) & 0x00FF) + amt;
            var g = (num & 0x0000FF) + amt;
            var newColor = g | (b << 8) | (r << 16);
            return ToColor(newColor);
        }

        private static Color ToColor(int hexVal) {
            var r = (byte)((hexVal >> 16) & 0xFF);
            var g = (byte)((hexVal >> 8) & 0xFF);
            var b = (byte)(hexVal & 0xFF);
            return new Color(r, g, b, 255) / 255;
        }
    }
}