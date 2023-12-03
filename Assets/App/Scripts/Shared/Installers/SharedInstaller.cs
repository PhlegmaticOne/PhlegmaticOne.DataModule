using App.Scripts.Common.Scenes;
using App.Scripts.Common.Scenes.Base;
using App.Scripts.Menu.Features.Statistics.Services;
using App.Scripts.Shared.Progress.Services;
using Assets.App.Scripts.Menu.Features.Statistics.Services;
using Zenject;

namespace App.Scripts.Shared.Installers {
    public class SharedInstaller : MonoInstaller {
        public override void InstallBindings() {
            BindSceneProvider();
            BindPlayerScoreService();
        }

        private void BindPlayerScoreService() {
            Container.Bind<IPlayerService>().To<PlayerService>().AsSingle();
            Container.Bind<IStatisticsService>().To<StatisticsService>().AsSingle();
        }
        
        private void BindSceneProvider() {
            Container.Bind<ISceneProvider>().To<SceneProvider>().AsSingle();
        }
    }
}