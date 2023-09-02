using App.Scripts.Common.Pools.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace App.Scripts.Common.Pools.PoolableTypes {
    public class PoolableUIElement : SerializedMonoBehaviour, IPoolableObjectBehaviour {
        protected UIElementsPool UIElementsPool;
        private RectTransform _rectTransform;

        [Inject]
        private void Construct(UIElementsPool uiElementsPool) => UIElementsPool = uiElementsPool;

        public RectTransform RectTransform =>
            _rectTransform != null ? _rectTransform : _rectTransform = GetComponent<RectTransform>();
        
        public virtual void OnInitialize() { }
        public virtual void OnSetup() { }
        public virtual void OnReset() { }
    }
}