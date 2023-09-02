using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhlegmaticOne.ViewModels.Properties;

namespace PhlegmaticOne.ViewModels.Contracts {
    public abstract class BaseViewModel : IViewModel {
        public virtual Task InitializeAsync() => Task.CompletedTask;
        protected virtual IEnumerable<IReactiveProperty> ReactiveProperties() => Enumerable.Empty<IReactiveProperty>();
        protected virtual void OnDisposing() { }
        
        public void Dispose() {
            foreach (var reactiveProperty in ReactiveProperties()) {
                reactiveProperty.PropertyChanged.RemoveAllListeners();
            }
            
            OnDisposing();
        }
    }
}