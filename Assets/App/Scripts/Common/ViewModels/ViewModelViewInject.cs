using PhlegmaticOne.ViewModels.Contracts;
using Zenject;

namespace App.Scripts.Common.ViewModels {
    public class ViewModelViewInject<T> : ViewModelView<T> where T : BaseViewModel {
        [Inject]
        private void Construct(T viewModel) => SetupViewModel(viewModel);
    }
}