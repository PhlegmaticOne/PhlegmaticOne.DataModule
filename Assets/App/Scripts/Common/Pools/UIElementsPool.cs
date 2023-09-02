using App.Scripts.Common.Pools.BasePool;
using App.Scripts.Common.Pools.PoolableTypes;
using UnityEngine;

namespace App.Scripts.Common.Pools {
    public class UIElementsPool : BaseObjectsPool<PoolableUIElement> {
        public override void ReturnToPool(PoolableUIElement behaviour) {
            behaviour.transform.localScale = Vector3.one;
            base.ReturnToPool(behaviour);
        }
    }
}