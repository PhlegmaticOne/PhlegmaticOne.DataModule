using App.Scripts.Common.Scenes;
using App.Scripts.Common.Scenes.Base;
using App.Scripts.Shared.Progress.Services;
using Zenject;

namespace App.Scripts.Shared.Installers {
    public class SharedInstaller : MonoInstaller {
        public override void InstallBindings() {
            BindSceneProvider();
            BindPlayerScoreService();
        }

        private void BindPlayerScoreService() {
            Container.Bind<IPlayerScoreService>().To<PlayerScoreService>().AsSingle();
        }
        
        private void BindSceneProvider() {
            Container.Bind<ISceneProvider>().To<SceneProvider>().AsSingle();
        }
    }
}