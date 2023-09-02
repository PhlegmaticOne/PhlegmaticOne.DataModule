using App.Scripts.Common.Pools.Interfaces;
using UnityEngine;

namespace App.Scripts.Common.Pools.BasePool {
    public class PoolableObject : MonoBehaviour {
        private IPoolableObjectBehaviour _behaviourComponent;
        public IPoolableObjectBehaviour BehaviourComponent {
            get {
                if (_behaviourComponent == null) {
                    try {
                        _behaviourComponent = GetComponent<IPoolableObjectBehaviour>();
                        if (_behaviourComponent == null) {
                            Debug.LogError(
                                $"[PoolableObject] Prefab {gameObject.name} doesn't contain component inherited from {nameof(IPoolableObjectBehaviour)}");
                        }
                    }
                    catch {
                        Debug.Log("E");
                    }
                }
                return _behaviourComponent;
            }
        }
    }
}