using App.Scripts.Game.Features._Boot;
using App.Scripts.Game.Features.Blocks.Services;
using App.Scripts.Game.Features.BlocksSplit.Factories;
using App.Scripts.Game.Features.Common;
using App.Scripts.Game.Features.Difficulty.Services;
using App.Scripts.Game.Features.Packages.Services;
using App.Scripts.Game.Features.Spawning.Factories;
using App.Scripts.Game.Infrastructure.Input;
using App.Scripts.Game.Infrastructure.Session;
using App.Scripts.Game.States;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Installers {
    public class CommonInstaller : MonoInstaller {
        [SerializeField] private Camera _camera;
        [SerializeField] private GameBootstrap _gameBootstrap;
        
        public override void InstallBindings() {
            BindCameraProvider();
            BindInputSystem();
            BindBlockService();
            BindDifficulty();
            BindNetworkSession();
            BindStates();
            BindBootstrap();
        }

        private void BindBootstrap() {
            Container.BindInterfacesTo<GameBootstrap>().FromInstance(_gameBootstrap).AsSingle();
        }

        private void BindNetworkSession() {
            Container.Bind<INetworkSession>().To<NetworkSession>().AsSingle();
        }

        private void BindStates() {
            Container.Bind<StateStartGame>().AsSingle();
            Container.Bind<StateWin>().AsSingle();
        }

        private void BindDifficulty() {
            Container.Bind<ISpawningDifficulty>().To<SpawningDifficultyDefault>().AsSingle();
            Container.Bind<IPackageGenerator>().To<PackageGenerator>().AsSingle();
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