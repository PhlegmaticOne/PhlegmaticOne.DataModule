using App.Scripts.Game.Features.Common;
using App.Scripts.Game.Infrastructure.Input;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game {
    public class CommonInstaller : MonoInstaller {
        [SerializeField] private Camera _camera;
        
        public override void InstallBindings() {
            BindCameraProvider();
            BindInputSystem();
        }

        private void BindInputSystem() {
            Container.Bind<IInputSystemFactory>().To<InputSystemFactory>().AsSingle();
        }

        private void BindCameraProvider() {
            Container.Bind<CameraProvider>().FromInstance(new CameraProvider(_camera)).AsSingle();
        }
    }
}