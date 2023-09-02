using System;
using System.Collections.Generic;
using App.Scripts.Common.Pools.Interfaces;

namespace App.Scripts.Common.Pools.BasePool.Containers {
    public class PrefabsContainer {
        private readonly Dictionary<Type, IPoolableObjectBehaviour> _prefabsMap = new();

        public PrefabsContainer(List<PoolableObject> poolableObjects) => SetupPrefabsMap(poolableObjects);

        public IPoolableObjectBehaviour GetPrefab(Type type) => _prefabsMap[type];

        private void SetupPrefabsMap(List<PoolableObject> poolableObjects) {
            foreach (var poolableObject in poolableObjects) {
                AddPrefab(poolableObject);
            }
        }
        
        private void AddPrefab(PoolableObject poolableObject) {
            var behaviour = poolableObject.BehaviourComponent;
            var type = behaviour.GetType();
            _prefabsMap.Add(type, behaviour);
        }
    }
}