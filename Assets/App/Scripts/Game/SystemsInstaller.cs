using App.Scripts.Game.BlocksState;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using App.Scripts.Game.Network;
using App.Scripts.Game.Physics;
using App.Scripts.Game.Spawning.Systems;
using Zenject;

namespace App.Scripts.Game {
    public class SystemsInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<NetworkService>().AsSingle();
            BindSystems();
        }

        private void BindSystems() {
            Container.Bind<ISystem>().To<SystemGravity>().AsSingle();
            Container.Bind<ISystem>().To<SystemSpawnByTime>().AsSingle();
            Container.Bind<ISystem>().To<SystemSpawning>().AsSingle();
            Container.Bind<ISystem>().To<SystemBlocksStateCheck>().AsSingle();
            Container.Bind<ISystem>().To<SystemTimers>().AsSingle();
            Container.Bind<ISystem>().To<SystemNetwork>().AsSingle();
        }
    }
}