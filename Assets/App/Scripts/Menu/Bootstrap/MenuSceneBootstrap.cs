using System;
using System.Threading.Tasks;
using App.Scripts.Common.Input;
using App.Scripts.Common.Input.Base;
using App.Scripts.Common.ViewModels;
using App.Scripts.Menu.Screen;
using UnityEngine;
using Zenject;

namespace App.Scripts.Menu.Bootstrap {
    public class MenuSceneBootstrap : MonoBehaviour, IInitializable, IDisposable {
        [SerializeField] private ViewModelViewsBootstrap _modelViewsBootstrap;
        [SerializeField] private MenuScreenView _menuScreenView;

        private IInputLocker _inputLocker;

        [Inject]
        private void Construct(IInputLocker inputLocker) {
            _inputLocker = inputLocker;
        }

        public async void Initialize()
        {
            await InitializeAsync();
        }

        public void Dispose() {
            _menuScreenView.Dispose();
            _modelViewsBootstrap.Dispose();
        }

        public async Task InitializeAsync() {
            await _modelViewsBootstrap.InitializeAsync();
            await _inputLocker.ExecuteInLocked(() => _menuScreenView.ShowAnimate());
        }
    }
}