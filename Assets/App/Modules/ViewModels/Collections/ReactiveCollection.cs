using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PhlegmaticOne.ViewModels.App.Modules.ViewModels.Collections {
    public class ReactiveCollection<T> : IEnumerable<T> {
        private List<T> _items;

        public event Action<T> ItemChanged; 

        public ReactiveCollection() => Initialize(new List<T>());

        public ReactiveCollection(IEnumerable<T> items) => Initialize(items);
        public void Initialize(IEnumerable<T> items) => _items = items.ToList();

        public int Index(T model) => _items.IndexOf(model);

        public void OnItemChanged(T item) {
            var index = _items.IndexOf(item);
            
            if (index == -1) {
                return;
            }
            
            ItemChanged?.Invoke(item);
        }

        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}