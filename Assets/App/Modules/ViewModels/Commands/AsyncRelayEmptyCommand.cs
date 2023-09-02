using System;
using System.Threading.Tasks;
using PhlegmaticOne.ViewModels.Commands.Base;

namespace PhlegmaticOne.ViewModels.Commands {
    internal class AsyncRelayEmptyCommand : RelayCommandBase {
        private readonly Func<Task> _action;
        private readonly Action<Exception> _onException;

        internal AsyncRelayEmptyCommand(Func<Task> action, 
            Predicate<object> canExecute = null,
            Action<Exception> onException = null) : base(canExecute) {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            _onException = onException;
        }

        public override async void Execute(object parameter) {
            SetIsExecuting(true);
            try {
                await _action.Invoke();
            }
            catch (Exception exception) when (_onException != null) {
                _onException.Invoke(exception);
            }
            SetIsExecuting(false);
        }
    }
}