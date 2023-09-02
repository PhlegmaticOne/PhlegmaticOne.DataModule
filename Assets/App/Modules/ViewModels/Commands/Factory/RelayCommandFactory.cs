using System;
using System.Threading.Tasks;

namespace PhlegmaticOne.ViewModels.Commands {
    public static class RelayCommandFactory {
        public static IRelayCommand CreateEmptyCommand(Action action,
            Predicate<object> canExecute = null) => 
            new RelayEmptyCommand(action, canExecute);

        public static IRelayCommand CreateCommand(Action<object> action,
            Predicate<object> canExecute = null) => 
            new RelayGenericCommand<object>(action, canExecute);
        public static IRelayCommand CreateCommand<T>(Action<T> action, 
            Predicate<object> canExecute = null) => 
            new RelayGenericCommand<T>(action, canExecute);
        public static IRelayCommand CreateEmptyAsyncCommand(Func<Task> action,
            Predicate<object> canExecute = null,
            Action<Exception> onException = null) =>
            new AsyncRelayEmptyCommand(action, canExecute, onException);

        public static IRelayCommand CreateAsyncCommand(Func<object, Task> action,
            Predicate<object> canExecute = null,
            Action<Exception> onException = null) => 
            new AsyncRelayGenericCommand<object>(action, canExecute, onException);

        public static IRelayCommand CreateAsyncCommand<T>(Func<T, Task> action, 
            Predicate<object> canExecute = null,
            Action<Exception> onException = null) =>
            new AsyncRelayGenericCommand<T>(action, canExecute, onException);
    }
}