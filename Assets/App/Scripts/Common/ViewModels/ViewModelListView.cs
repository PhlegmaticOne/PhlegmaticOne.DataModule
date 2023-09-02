using System.Collections.Generic;
using System.Linq;
using App.Scripts.Common.Pools;
using PhlegmaticOne.ViewModels.App.Modules.ViewModels.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Scripts.Common.ViewModels {
    public abstract class ViewModelListView<TModel, TView> : MonoBehaviour where TView : ViewModelListViewItem<TModel> {
        private ReactiveCollection<TModel> _reactiveCollection;
        private List<TView> _views;
        private UIElementsPool _uiElementsPool;

        protected virtual RectTransform ContentTransform => (RectTransform)transform;

        [Inject]
        private void Construct(UIElementsPool uiElementsPool) {
            _uiElementsPool = uiElementsPool;
        }

        public void Setup(ReactiveCollection<TModel> reactiveCollection) {
            _reactiveCollection = reactiveCollection;
            _views = new List<TView>();
            _reactiveCollection.ItemChanged += UpdateView;
            SpawnViews();
        }
        
        public void Dispose() {
            foreach (var view in _views) {
                _uiElementsPool.ReturnToPool(view);
            }
            
            _views.Clear();
            _reactiveCollection.ItemChanged -= UpdateView;
            _reactiveCollection = null;
        }
        
        protected IEnumerable<(TView, TModel)> ViewModelEntries() {
            return _views.Zip(_reactiveCollection, (view, model) => (view, model));
        }

        private void UpdateView(TModel model) {
            var index = _reactiveCollection.Index(model);
            var view = _views[index];
            view.UpdateView(model);
        }

        private void SpawnViews() {
            foreach (var item in _reactiveCollection) {
                var view = _uiElementsPool.GetFromPool<TView>(ContentTransform);
                view.UpdateView(item);
                _views.Add(view);
            }
            
            LayoutRebuilder.ForceRebuildLayoutImmediate(ContentTransform);
        }
    }
}