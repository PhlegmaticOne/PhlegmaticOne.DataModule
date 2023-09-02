using App.Scripts.Common.Pools.Factories;
using App.Scripts.Common.Pools.PoolableTypes;
using UnityEngine;
using Zenject;

namespace App.Scripts.Common.Pools.Installer {
    public class PoolsInstaller : MonoInstaller {
        [SerializeField] private DialogsPool _dialogsPool;
        [SerializeField] private UIElementsPool _uiElementsPool;
        
        public override void InstallBindings() {
            BindDialogsPool();
            BindUIElementsPool();
        }
        
        private void BindUIElementsPool() {
            Container.Bind<IFactory<PoolableUIElement, PoolableUIElement>>().To<PoolFactory<PoolableUIElement>>().AsSingle();
            Container.Bind<UIElementsPool>().FromInstance(_uiElementsPool).AsSingle();
        }

        private void BindDialogsPool() {
            Container.Bind<IFactory<PoolableDialog, PoolableDialog>>().To<PoolFactory<PoolableDialog>>().AsSingle();
            Container.Bind<DialogsPool>().FromInstance(_dialogsPool).AsSingle();
        }
    }
}