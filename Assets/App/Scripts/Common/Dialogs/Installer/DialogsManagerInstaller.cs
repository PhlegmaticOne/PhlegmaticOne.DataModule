using App.Scripts.Common.Dialogs.Manager;
using UnityEngine;
using Zenject;

namespace App.Scripts.Common.Dialogs.Installer {
    public class DialogsManagerInstaller : MonoInstaller {
        [SerializeField] private RectTransform _dialogsTransform;
        public override void InstallBindings() {
            Container.Bind<DialogsManagerSettings>().FromInstance(new DialogsManagerSettings(_dialogsTransform)).AsSingle();
            Container.BindInterfacesTo<DialogsManager>().AsSingle();
        }
    }
}