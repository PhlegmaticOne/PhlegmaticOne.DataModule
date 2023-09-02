using System.Threading.Tasks;
using App.Scripts.Common.Boot.Contracts;
using App.Scripts.Common.Input;
using App.Scripts.Common.Input.Base;
using App.Scripts.Menu.Screen;
using UnityEngine;
using Zenject;

namespace App.Scripts.Menu.Bootstrap {
    public class MenuSceneBootstrap : MonoBehaviour, ISceneInitializer {
        [SerializeField] private MenuScreenView _menuScreenView;

        private IInputLocker _inputLocker;

        [Inject]
        private void Construct(IInputLocker inputLocker) {
            _inputLocker = inputLocker;
        }
        
        public async Task InitializeAsync() {
            await _inputLocker.ExecuteInLocked(() => _menuScreenView.ShowAnimate());
        }
    }
}