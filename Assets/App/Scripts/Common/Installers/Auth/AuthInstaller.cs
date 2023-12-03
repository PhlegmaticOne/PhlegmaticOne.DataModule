using PhlegmaticOne.Auth;
using PhlegmaticOne.Auth.App.Modules.Auth.Editor;
using PhlegmaticOne.Auth.Assets.App.Modules.Auth;
using PhlegmaticOne.Auth.Google;
using UnityEngine;
using Zenject;

namespace App.Scripts.Common.Installers.Auth
{
    public class AuthInstaller : MonoInstaller {
        [SerializeField] private ApplicationAuthType _authType;
        
        public override void InstallBindings() {
            #if UNITY_EDITOR || UNITY_STANDALONE_WIN
                BindEditorAuth();
            #else
                BindAuth();
            #endif
        }

        private void BindEditorAuth() {
            Container.BindInterfacesTo<EmailPasswordAuthProvider>().AsSingle();
        }

        private void BindAuth() {
            switch (_authType) {
                case ApplicationAuthType.None: BindEditorAuth(); break;
                case ApplicationAuthType.Google: BindGoogleAuth(); break;
                default: BindEditorAuth(); break;
            }
        }

        private void BindGoogleAuth() {
            Container.Bind<IAuthSource>().To<EmpryAuthSource>().AsSingle();
            Container.BindInterfacesTo<GoogleAuthProvider>().AsSingle();
            Container.BindInterfacesTo<GoogleAuthOptions>().AsSingle();
        }

        private class GoogleAuthOptions : IGoogleAuthOptions {
            
            private const string ClientId = "495078283376-hul3qqag290jrgke2sm4crmmrake6e0h.apps.googleusercontent.com";
            public string WebClientId => ClientId;
        }
    }
}