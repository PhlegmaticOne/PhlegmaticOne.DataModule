using App.Scripts.Game.Features.Blocks.Systems;
using App.Scripts.Game.Features.BoardState.Systems;
using App.Scripts.Game.Features.Cutting.Systems;
using App.Scripts.Game.Features.Network.Systems;
using App.Scripts.Game.Features.Physics.Systems;
using App.Scripts.Game.Features.Spawning.Systems;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using Zenject;

namespace App.Scripts.Game.Installers {
    public class SystemsInstaller : MonoInstaller {
        public override void InstallBindings() {
            BindSystems();
        }

        private void BindSystems() {
            Container.Bind<ISystem>().To<SystemGravity>().AsSingle();
            Container.Bind<ISystem>().To<SystemSpawnByTime>().AsSingle();
            Container.Bind<ISystem>().To<SystemSpawning>().AsSingle();
            Container.Bind<ISystem>().To<SystemCuttingInput>().AsSingle();
            Container.Bind<ISystem>().To<SystemCuttingView>().AsSingle();
            Container.Bind<ISystem>().To<SystemCuttingAction>().AsSingle();
            Container.Bind<ISystem>().To<SystemCuttingDestroyBlocks>().AsSingle();
            Container.Bind<ISystem>().To<SystemBoardStateCheck>().AsSingle();
            Container.Bind<ISystem>().To<SystemTimers>().AsSingle();
            Container.Bind<ISystem>().To<SystemRemoveBlocks>().AsSingle();
            Container.Bind<ISystem>().To<SystemNetwork>().AsSingle();
        }
    }
}