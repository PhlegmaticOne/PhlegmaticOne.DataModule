using App.Scripts.Common.Pools.Interfaces;
using Sirenix.OdinInspector;

namespace App.Scripts.Common.Pools.PoolableTypes {
    public class PoolableDialog : SerializedMonoBehaviour, IPoolableObjectBehaviour {
        public virtual void OnInitialize() { }
        public virtual void OnSetup() { }
        public virtual void OnReset() { }
    }
}