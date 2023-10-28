using App.Scripts.Game.Features.Combo.Components;
using App.Scripts.Game.Features.Combo.Configs;
using App.Scripts.Game.Features.Common;
using UnityEngine;

namespace App.Scripts.Game.Features.Combo.Factory {
    public class ComboTextFactory : IComboTextFactory {
        private readonly ComboFactoryConfig _config;
        private readonly CameraProvider _cameraProvider;

        public ComboTextFactory(ComboFactoryConfig config, CameraProvider cameraProvider) {
            _config = config;
            _cameraProvider = cameraProvider;
        }
        
        public void ShowComboText(ComponentShowComboText componentShowComboText) {
            var config = _config.ComboConfig;
            var comboText = Object.Instantiate(config.Prefab, _config.SpawnTransform);
            var s = comboText.HalfSize;
            var screenPosition = _cameraProvider.WorldToScreen(componentShowComboText.PositionWorld);
            screenPosition.x = Mathf.Clamp(screenPosition.x + s.x, 0, Screen.width) - s.x;
            screenPosition.y = Mathf.Clamp(screenPosition.y + s.y, 0, Screen.height) - s.y;
            comboText.SetPosition(screenPosition);
            comboText.ShowAnimate(componentShowComboText.ComboValue, config.ShowTextTime);
        }
    }
}