using System;
using PhlegmaticOne.ViewModels.Properties;

namespace PhlegmaticOne.ViewModels.Extensions {
    public static class ViewModelExtensions {
        public static TViewModel Subscribe<TViewModel, T>(
            this TViewModel viewModel, 
            Func<TViewModel, ReactiveProperty<T>> reactiveProperty,
            Action<T> action) 
        {
            var property = reactiveProperty(viewModel);
            property.PropertyChanged.AddListener(() => action?.Invoke(property.Value));
            return viewModel;
        }
    }
}