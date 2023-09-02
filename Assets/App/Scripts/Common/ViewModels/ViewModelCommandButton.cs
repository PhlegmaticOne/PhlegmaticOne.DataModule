using PhlegmaticOne.ViewModels.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Common.ViewModels {
    [RequireComponent(typeof(Button))]
    public class ViewModelCommandButton : MonoBehaviour {
        [SerializeField] private Button _button;
        
        private IRelayCommand _relayCommand;
        private object _parameter;

        private void OnValidate() => _button = GetComponent<Button>();

        public void Setup(IRelayCommand relayCommand, object parameter = null) {
            if (relayCommand is null) {
                return;
            }
            
            _parameter = parameter;
            _relayCommand = relayCommand;
            _relayCommand.CanExecuteChanged += UpdateButtonState;
            _button.onClick.AddListener(ExecuteCommand);
        }

        public void Dispose() {
            if (_relayCommand is null) {
                return;
            }
            
            _relayCommand.CanExecuteChanged -= UpdateButtonState;
            _button.onClick.RemoveAllListeners();
            _relayCommand = null;
        }

        private void ExecuteCommand() => _relayCommand?.Execute(_parameter);
        private void UpdateButtonState() {
            if (_relayCommand is null) {
                return;
            }
            
            _button.interactable = _relayCommand.CanExecute();
        }
    }
}