using App.Scripts.Game.Features.Cutting.Views;
using UnityEngine;

namespace App.Scripts.Game.Features.Cutting.Factories {
    public class BladeFactory : IBladeFactory {
        private readonly BladeFactoryConfig _bladeFactoryConfig;

        public BladeFactory(BladeFactoryConfig bladeFactoryConfig) {
            _bladeFactoryConfig = bladeFactoryConfig;
        }
        
        public BladeView Create(bool isRemote) {
            var view = Object.Instantiate(_bladeFactoryConfig.BladeView, _bladeFactoryConfig.SpawnTransform);
            var point = isRemote ? _bladeFactoryConfig.RemoteBladePoint : _bladeFactoryConfig.LocalBladePoint;
            view.transform.position = point;
            return view;
        }
    }
}