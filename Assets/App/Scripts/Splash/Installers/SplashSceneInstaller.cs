using App.Scripts.Splash.Bootstrap;
using App.Scripts.Splash.Features.Progress.Models;
using App.Scripts.Splash.Features.Progress.ViewModels;
using App.Scripts.Splash.Services.Firebase;
using App.Scripts.Splash.Services.Initializer;
using UnityEngine;
using Zenject;

namespace App.Scripts.Splash.Installers {
    public class SplashSceneInstaller : MonoInstaller {
        [SerializeField] private SplashBootstrap _bootstrap;
        [Header("Progress Reporter")] 
        [SerializeField] [Range(5, 50)] private int _progressDeltaTime;
        [SerializeField] [Range(0, 1000)] private int _finalProgressDelay;

        public override void InstallBindings() {
            BindAppInitializer();
            BindFirebaseInitializer();
            BindProgressReporter();
            BindBootstrap();
        }

        private void BindAppInitializer() {
            Container.BindInterfacesTo<AppInitializer>().AsSingle();
        }
        
        private void BindBootstrap() {
            Container.BindInterfacesTo<SplashBootstrap>().FromInstance(_bootstrap).AsSingle();
        }

        private void BindFirebaseInitializer() {
            #if UNITY_EDITOR
                Container.BindInterfacesTo<FakeFirebaseInitializer>().AsSingle();
            #else
                Container.BindInterfacesTo<FirebaseInitializer>().AsSingle();
            #endif
        }

        private void BindProgressReporter() {
            Container.Bind<IProgressReporter>()
                .FromInstance(new AsyncProgressReporter(_progressDeltaTime, _finalProgressDelay))
                .AsSingle();
            Container.Bind<ProgressReporterViewModel>().AsSingle();
        }
    }
}