using System;

namespace PhlegmaticOne.ViewModels.Commands {
    public interface IRelayCommand {
        event Action CanExecuteChanged;
        void Execute(object parameter = null);
        bool CanExecute(object parameter = null);
        void RaiseCanExecute();
    }
}