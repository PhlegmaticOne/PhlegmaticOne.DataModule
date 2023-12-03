using App.Scripts.Menu.Bootstrap;
using App.Scripts.Menu.Features.Progress.ViewModels;
using App.Scripts.Menu.Features.Statistics.Services;
using App.Scripts.Menu.Features.Statistics.ViewModels;
using App.Scripts.Menu.Screen;
using App.Scripts.Menu.Screen.ViewModel;
using App.Scripts.Menu.Services.Exit;
using Assets.App.Scripts.Menu.Features.Settings.ViewModel;
using Assets.App.Scripts.Menu.Features.Statistics.Services;
using UnityEngine;
using Zenject;

namespace App.Scripts.Menu.Installer {
    public class MenuSceneInstaller : MonoInstaller {
        [SerializeField] private MenuSceneBootstrap _bootstrap;
        
        public override void InstallBindings() {
            BindPlayerViewModel();
            BindStatisticsViewModel();
            BindMenuScreen();
            BindExitService();
            BindBootstrap();
            BindLeaderboard();
            BindSettings();
        }

        private void BindSettings()
        {
            Container.Bind<SettingsDialogViewModel>().AsSingle();
        }

        private void BindLeaderboard()
        {
            Container.Bind<LeaderboardViewModel>().AsSingle();
            Container.Bind<ILeaderboadSelectService>().To<LeaderboardSelectService>().AsSingle();
        }

        private void BindBootstrap() {
            Container.BindInterfacesTo<MenuSceneBootstrap>().FromInstance(_bootstrap).AsSingle();
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