using App.Scripts.Game.Infrastructure.Ecs.Worlds;
using Zenject;

namespace App.Scripts.Game.Infrastructure.Ecs {
    public class WorldInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<World>().AsSingle();
        }
    }
}