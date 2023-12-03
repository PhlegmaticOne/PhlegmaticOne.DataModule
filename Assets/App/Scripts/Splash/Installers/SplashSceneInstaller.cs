using App.Scripts.Splash.Bootstrap;
using App.Scripts.Splash.Features.Progress.Models;
using App.Scripts.Splash.Features.Progress.ViewModels;
using App.Scripts.Splash.Services.Firebase;
using App.Scripts.Splash.Services.Initializer;
using PhlegmaticOne.Auth.Assets.App.Modules.Auth;
using PhlegmaticOne.Auth.Assets.App.Modules.Auth.EmailPassword;
using UnityEngine;
using Zenject;

namespace App.Scripts.Splash.Installers {
    public class SplashSceneInstaller : MonoInstaller {
        [SerializeField] private SplashBootstrap _bootstrap;
        [SerializeField] private EmailPasswordAuthWindow _authWindow;
        [Header("Progress Reporter")] 
        [SerializeField] [Range(5, 50)] private int _progressDeltaTime;
        [SerializeField] [Range(0, 1000)] private int _finalProgressDelay;

        public override void InstallBindings() {
            BindAuthWindow();
            BindAppInitializer();
            BindFirebaseInitializer();
            BindProgressReporter();
            BindBootstrap();
        }

        private void BindAuthWindow()
        {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            _authWindow.SetRawData("editor@gmail.com", "Qwerty!1234");
            Container.Bind<IAuthSource>().FromInstance(_authWindow).AsSingle();
#endif
        }

        private void BindAppInitializer() {
            Container.BindInterfacesTo<AppInitializer>().AsSingle();
        }
        
        private void BindBootstrap() {
            Container.BindInterfacesTo<SplashBootstrap>().FromInstance(_bootstrap).AsSingle();
        }

        private void BindFirebaseInitializer() {
            Container.BindInterfacesTo<FirebaseInitializer>().AsSingle();
        }

        private void BindProgressReporter() {
            Container.Bind<IProgressReporter>()
                .FromInstance(new AsyncProgressReporter(_progressDeltaTime, _finalProgressDelay))
                .AsSingle();
            Container.Bind<ProgressReporterViewModel>().AsSingle();
        }
    }
}