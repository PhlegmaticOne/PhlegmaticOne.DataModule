using App.Scripts.Common.Pools.Interfaces;
using UnityEngine;
using Zenject;

namespace App.Scripts.Common.Pools.Factories {
    public class PoolFactory<TObject> : IFactory<TObject, TObject> 
        where TObject : MonoBehaviour, IPoolableObjectBehaviour {
        private readonly DiContainer _container;

        public PoolFactory(DiContainer container) {
            _container = container;
        }

        public TObject Create(TObject prefab) {
            var poolableObject = _container.InstantiatePrefabForComponent<TObject>(prefab);
            return poolableObject;
        }
    }
}