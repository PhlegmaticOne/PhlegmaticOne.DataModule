using UnityEngine;

namespace App.Scripts.Common.Dialogs.Manager {
    public class DialogsManagerSettings {
        public Transform DialogsTransform { get; }

        public DialogsManagerSettings(Transform dialogsTransform) {
            DialogsTransform = dialogsTransform;
        }
    }
}