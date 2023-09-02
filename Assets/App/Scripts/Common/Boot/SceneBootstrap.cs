using System.Collections.Generic;
using System.Linq;
using App.Scripts.Common.Boot.Contracts;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace App.Scripts.Common.Boot {
    public class SceneBootstrap : SerializedMonoBehaviour, IInitializable {
        [SerializeField] private List<ISceneInitializer> _componentInitializers;
        [SerializeField] private List<ISceneStarter> _sceneStarters;
        [SerializeField] private List<ISceneDisposer> _sceneDisposers;

        public async void Initialize() {
            foreach (var componentInitializer in _componentInitializers) {
                await componentInitializer.InitializeAsync();
            }

            foreach (var sceneStarter in _sceneStarters) {
                sceneStarter.Start();
            }
        }

        public void DisposeScene() {
            foreach (var sceneDisposer in _sceneDisposers) { 
                sceneDisposer.Dispose();
            }
        }


        [Button]
        private void UpdateInitializers() {
            _componentInitializers = FindObjectsOfType<MonoBehaviour>().OfType<ISceneInitializer>().ToList();
        }
        
        [Button]
        private void UpdateStarters() {
            _sceneStarters = FindObjectsOfType<MonoBehaviour>().OfType<ISceneStarter>().ToList();
        }
        
        [Button]
        private void UpdateDisposers() {
            _sceneDisposers = FindObjectsOfType<MonoBehaviour>().OfType<ISceneDisposer>().ToList();
        }
    }
}