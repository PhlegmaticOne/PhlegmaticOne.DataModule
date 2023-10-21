using App.Scripts.Game.Features.Network.Services;
using Zenject;

namespace App.Scripts.Game.Features.Network.Installer {
    public class NetworkInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<INetworkService>().To<NetworkService>().AsSingle();
        }
    }
}