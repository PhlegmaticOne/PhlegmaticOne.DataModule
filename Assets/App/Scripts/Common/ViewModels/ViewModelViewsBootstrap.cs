using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Scripts.Common.Boot.Contracts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Common.ViewModels {
    public class ViewModelViewsBootstrap : MonoBehaviour, ISceneInitializer, ISceneDisposer {
        
        [SerializeField] private List<ViewModelView> _viewModelViewsOnScene;
        public async Task InitializeAsync() {
            foreach (var viewModelView in _viewModelViewsOnScene) {
                await viewModelView.InitializeAsync();
            }
        }

        public void Dispose() {
            foreach (var viewModelView in _viewModelViewsOnScene) {
                viewModelView.Dispose();
            }
        }

        [Button]
        private void FindViewModelViewsOnScene() {
            _viewModelViewsOnScene = FindObjectsOfType<ViewModelView>().ToList();
        }
    }
}