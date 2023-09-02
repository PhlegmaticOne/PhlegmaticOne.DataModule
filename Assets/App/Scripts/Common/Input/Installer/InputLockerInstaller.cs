using UnityEngine;
using Zenject;

namespace App.Scripts.Common.Input.Installer {
    public class InputLockerInstaller : MonoInstaller {
        [SerializeField] private InputLocker _inputLocker;

        public override void InstallBindings() {
            Container.BindInterfacesTo<InputLocker>().FromInstance(_inputLocker).AsSingle();
        }
    }
}