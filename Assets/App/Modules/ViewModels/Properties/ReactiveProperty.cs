namespace PhlegmaticOne.ViewModels.Properties {
    public class ReactiveProperty<T> : IReactiveProperty {
        private T _value;
        
        public CallbackEvent PropertyChanged { get; }
        
        public ReactiveProperty() => PropertyChanged = new CallbackEvent();

        public T Value { get => _value; set => SetField(ref _value, value); }
        
        
        public static implicit operator T(ReactiveProperty<T> reactiveProperty) => reactiveProperty._value;

        private void OnPropertyChanged() => PropertyChanged?.Invoke();

        private void SetField(ref T field, T value) {
            field = value;
            OnPropertyChanged();
        }
    }
}