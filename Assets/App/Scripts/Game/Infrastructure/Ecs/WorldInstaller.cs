using Zenject;

namespace App.Scripts.Game.Infrastructure.Ecs {
    public class WorldInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<World.World>().AsSingle();
        }
    }
}