using App.Scripts.Game.Infrastructure.Ecs;
using App.Scripts.Game.Physics;
using Zenject;

namespace App.Scripts.Game.Infrastructure.Installers {
    public class GameSceneInstaller : MonoInstaller {
        public override void InstallBindings() {
            BindSystems();
        }

        private void BindSystems() {
            Container.Bind<ISystem>().To<GravitySystem>().AsSingle();
        }
    }
}