using System;
using System.Threading.Tasks;
using PhlegmaticOne.ViewModels.Contracts;
using UnityEngine;

namespace App.Scripts.Common.ViewModels {
    public abstract class ViewModelView : MonoBehaviour, IDisposable {
        public abstract Task InitializeAsync();
        public abstract void Dispose();
    }
    
    public class ViewModelView<T> : ViewModelView where T : BaseViewModel {
        protected void SetupViewModel(T viewModel) => ViewModel = viewModel;
        
        public T ViewModel { get; private set; }

        public override async Task InitializeAsync() {
            await ViewModel.InitializeAsync();
            OnInitializing();
        }

        public override void Dispose() {
            ViewModel.Dispose();
            OnDisposing();
        }

        protected virtual void OnInitializing() { }

        protected virtual void OnDisposing() { }
    }
}