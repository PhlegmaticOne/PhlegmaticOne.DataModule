using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Features.BlocksSplit.Factories;
using App.Scripts.Game.Features.Common;
using App.Scripts.Game.Features.Spawning.Factories;
using App.Scripts.Game.Infrastructure.Input;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Installers {
    public class CommonInstaller : MonoInstaller {
        [SerializeField] private Camera _camera;
        
        public override void InstallBindings() {
            BindCameraProvider();
            BindInputSystem();
            BindBlockService();
        }

        private void BindBlockService() {
            Container.Bind<IBlockContainer>().To<BlockContainer>().AsSingle();
            Container.Bind<IBlockFactory>().To<BlockFactory>().AsSingle();
            Container.Bind<IBlockSplitter>().To<BlockSplitter>().AsSingle();
        }

        private void BindInputSystem() {
            Container.Bind<IInputSystemFactory>().To<InputSystemFactory>().AsSingle();
        }

        private void BindCameraProvider() {
            Container.Bind<CameraProvider>().FromInstance(new CameraProvider(_camera)).AsSingle();
        }
    }
}