using System;
using PhlegmaticOne.ViewModels.Commands.Base;

namespace PhlegmaticOne.ViewModels.Commands {
    internal class RelayGenericCommand<T> : RelayCommandBase {
        private readonly Action<T> _action;
        private readonly bool _isRequired;

        internal RelayGenericCommand(Action<T> action, Predicate<object> canExecute = null, bool isRequired = false) : 
            base(canExecute) {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            _isRequired = isRequired;
        }
        
        public override void Execute(object parameter)
        {
            if(parameter is not T generic) {
                if(_isRequired == false) {
                    Invoke(default);
                }
                return;
            }

            Invoke(generic);
        }
        
        private void Invoke(T parameter) {
            SetIsExecuting(true);
            _action.Invoke(parameter);
            SetIsExecuting(false);
        }
    }
}