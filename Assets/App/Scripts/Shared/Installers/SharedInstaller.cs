using App.Scripts.Shared.Progress.Services;
using Zenject;

namespace App.Scripts.Shared.Installers {
    public class SharedInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<IPlayerScoreService>().To<PlayerScoreService>().AsSingle();
        }
    }
}