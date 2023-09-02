using App.Scripts.Menu.Features.Progress.ViewModels;
using App.Scripts.Menu.Features.Statistics.ViewModels;
using App.Scripts.Menu.Screen;
using App.Scripts.Menu.Screen.ViewModel;
using App.Scripts.Menu.Services.Exit;
using Zenject;

namespace App.Scripts.Menu.Installer {
    public class MenuSceneInstaller : MonoInstaller {
        public override void InstallBindings() {
            BindPlayerViewModel();
            BindStatisticsViewModel();
            BindMenuScreen();
            BindExitService();
        }

        private void BindExitService() {
            #if UNITY_EDITOR
                Container.BindInterfacesTo<ExitGameServiceEditor>().AsSingle();
            #else
                Container.BindInterfacesTo<ExitGameServiceCommon>().AsSingle();
            #endif
        }

        private void BindMenuScreen() {
            Container.Bind<MenuScreenViewModel>().AsSingle();
            Container.Bind<MenuScreenView>().AsSingle();
        }

        private void BindPlayerViewModel() {
            Container.Bind<PlayerScoreViewModel>().AsSingle();
        }
        
        private void BindStatisticsViewModel() {
            Container.Bind<StatisticsViewModel>().AsSingle();
        }
    }
}