using System;
using System.Collections.Generic;
using App.Scripts.Common.Pools.Interfaces;
using UnityEngine;

namespace App.Scripts.Common.Pools.BasePool.Containers {
    public class PoolContainer {
        private readonly Dictionary<Type, Transform> _containersMap = new();
        private readonly Dictionary<Type, Stack<IPoolableObjectBehaviour>> _poolMap = new();
        
        public PoolContainer(List<PoolableObject> poolableObjects, Transform poolTransform) {
            SetupPoolContainer(poolableObjects, poolTransform);
        }
        
        public bool HasElement(Type type, IPoolableObjectBehaviour behaviour) => _poolMap[type].Contains(behaviour);
        public bool ContainPool(Type type) => _poolMap.ContainsKey(type);
        public bool HasPoolObjects(Type type) => _poolMap[type].Count != 0;
        public IPoolableObjectBehaviour Pop(Type type) => _poolMap[type].Pop();
        public void Push(Type type, IPoolableObjectBehaviour behaviour) => _poolMap[type].Push(behaviour);
        public Transform GetPoolTransform(Type type) => _containersMap[type];
        
        private void SetupPoolContainer(List<PoolableObject> poolableObjects, Transform poolTransform) {
            foreach (var poolableObject in poolableObjects) {
                var type = poolableObject.BehaviourComponent.GetType();
                AddContainer(poolTransform, type);
                AddPool(type);
            }
        }

        private void AddContainer(Transform poolTransform, Type type) {
            var container = new GameObject($"{type.Name} Pool", typeof(RectTransform));
            container.SetActive(false);
            container.transform.SetParent(poolTransform);
            _containersMap.Add(type, container.transform);
        }
        
        private void AddPool(Type type) => _poolMap.Add(type, new Stack<IPoolableObjectBehaviour>());
    }
}