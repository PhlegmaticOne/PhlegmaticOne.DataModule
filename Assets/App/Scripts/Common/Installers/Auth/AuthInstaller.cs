using PhlegmaticOne.Auth.Fake;
using PhlegmaticOne.Auth.Google;
using UnityEngine;
using Zenject;

namespace App.Scripts.Common.Installers.Auth {
    public class AuthInstaller : MonoInstaller {
        [SerializeField] private ApplicationAuthType _authType;
        
        public override void InstallBindings() {
            #if UNITY_EDITOR
                BindFakeAuth();
            #else
                BindAuth();
            #endif
        }

        private void BindFakeAuth() {
            Container.BindInterfacesTo<FakeAuthProvider>().AsSingle();
        }

        private void BindAuth() {
            switch (_authType) {
                case ApplicationAuthType.None: BindFakeAuth(); break;
                case ApplicationAuthType.Google: BindGoogleAuth(); break;
                default: BindFakeAuth(); break;
            }
        }

        private void BindGoogleAuth() {
            Container.BindInterfacesTo<GoogleAuthProvider>().AsSingle();
            Container.BindInterfacesTo<GoogleAuthOptions>().AsSingle();
        }

        private class GoogleAuthOptions : IGoogleAuthOptions {
            
            private const string ClientId = "495078283376-hul3qqag290jrgke2sm4crmmrake6e0h.apps.googleusercontent.com";
            public string WebClientId => ClientId;
        }
    }
}