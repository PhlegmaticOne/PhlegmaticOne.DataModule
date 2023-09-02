using App.Scripts.Common.Pools.PoolableTypes;

namespace App.Scripts.Common.ViewModels {
    public abstract class ViewModelListViewItem<T> : PoolableUIElement {
        public abstract void UpdateView(T model);
    }
}