using System;
using System.Collections.Generic;
using App.Scripts.Common.Pools.BasePool.Containers;
using App.Scripts.Common.Pools.Interfaces;
using App.Scripts.Common.Utils;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace App.Scripts.Common.Pools.BasePool {
    public abstract class BaseObjectsPool<TObjectBehaviour> : SerializedMonoBehaviour
        where TObjectBehaviour : MonoBehaviour, IPoolableObjectBehaviour {
        [SerializeField] private List<PoolableObject> _prefabs;
        [SerializeField] private Object _prefabsFolder;
        
        private PoolContainer _poolContainer;
        private PrefabsContainer _prefabsContainer;
        private IFactory<TObjectBehaviour, TObjectBehaviour> _factory;
        
        [Inject]
        private void Construct(IFactory<TObjectBehaviour, TObjectBehaviour> factory) {
            _factory = factory;
        }

        private void Awake() {
            _prefabsContainer = new PrefabsContainer(_prefabs);
            _poolContainer = new PoolContainer(_prefabs, transform);
        }

        public TObject GetFromPool<TObject>(Vector3 position, Transform parent) where TObject : TObjectBehaviour {
            var poolableObject = GetFromPool<TObject>(parent);
            poolableObject.transform.position = position;
            return poolableObject;
        }

        public TObject GetFromPool<TObject>(Transform parent) where TObject : TObjectBehaviour {
            var poolableObject = GetFromPool<TObject>();
            poolableObject.transform.SetParent(parent, false);
            return poolableObject;
        }

        protected TObject GetFromPool<TObject>() where TObject : TObjectBehaviour {
            var type = typeof(TObject);
            if (!_poolContainer.ContainPool(type)) {
                Debug.LogError($"[ObjectsPool] {GetType()} doesn't contain objects of type {type.Name}.");
                return null;
            }
            var behaviour = GetBehaviourFromPool(type) as TObject;
            behaviour.gameObject.SetActive(true);
            return behaviour;
        }

        public virtual void ReturnToPool(TObjectBehaviour behaviour) {
            var type = behaviour.GetType();
            if (!_poolContainer.ContainPool(type)) {
                Debug.LogError($"[ObjectsPool] {GetType()} doesn't contain objects of type {type.Name}.");
                return;
            }
            
            if(!_poolContainer.HasElement(type, behaviour)) {
                ReturnBehaviourToPool(behaviour, type);
            }
        }

        private IPoolableObjectBehaviour GetBehaviourFromPool(Type type) {
            var poolableObject = _poolContainer.HasPoolObjects(type) ? _poolContainer.Pop(type) : InstantiatePoolObject(type);
            poolableObject.OnSetup();
            return poolableObject;
        }

        private void ReturnBehaviourToPool(TObjectBehaviour behaviour, Type type) {
            behaviour.OnReset();
            behaviour.gameObject.SetActive(false);
            SetPoolTransform(type, behaviour);
            _poolContainer.Push(type, behaviour);
        }

        private TObjectBehaviour InstantiatePoolObject(Type type) {
            var prefab = _prefabsContainer.GetPrefab(type) as TObjectBehaviour;
            var instantiateObject = _factory.Create(prefab);
            instantiateObject.OnInitialize();
            return instantiateObject;
        }

        private void SetPoolTransform(Type type, TObjectBehaviour objectBehaviour) {
            var poolTransform = _poolContainer.GetPoolTransform(type);
            objectBehaviour.transform.SetParent(poolTransform, false);
        }

        #if UNITY_EDITOR
            [Button]
            private void UpdatePrefabs() {
                _prefabs.Clear();
                foreach (var prefab in AssetUtils.LoadAssets<GameObject>(_prefabsFolder)) {
                    if (prefab.TryGetComponent<PoolableObject>(out var poolableObject) &&
                        HasBehaviourComponent(poolableObject)) {
                        _prefabs.Add(poolableObject);
                    }
                }
            }  
        #endif
        
        private static bool HasBehaviourComponent(PoolableObject poolableObject) {
            return poolableObject.BehaviourComponent is TObjectBehaviour;
        }
    }
}