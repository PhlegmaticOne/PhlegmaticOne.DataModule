using System;
using PhlegmaticOne.ViewModels.Commands.Costants;

namespace PhlegmaticOne.ViewModels.Commands.Base {
    internal abstract class RelayCommandBase : IRelayCommand {
        private readonly Predicate<object> _canExecute;
        private bool _isExecuting;

        internal RelayCommandBase(Predicate<object> canExecute) => _canExecute = canExecute ?? Predicates.True;

        public event Action CanExecuteChanged;

        public bool CanExecute(object parameter) => !_isExecuting && _canExecute.Invoke(parameter);

        public abstract void Execute(object parameter);

        public void RaiseCanExecute() => CanExecuteChanged?.Invoke();

        protected void SetIsExecuting(bool value) {
            _isExecuting = value;
            RaiseCanExecute();
        }
    }
}