using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Common.Dialogs.Animators {
    public abstract class BaseDialogAnimator : MonoBehaviour {
        public virtual void Setup() { }
        public abstract UniTask PlayShowAnimation();
        public abstract UniTask PlayCloseAnimation();
    }
}