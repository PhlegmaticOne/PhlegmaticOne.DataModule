using App.Scripts.Common.ViewModels;
using Assets.App.Scripts.Menu.Features.Settings.ViewModel;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.App.Scripts.Menu.Features.Settings.Views
{
    public class SettingsDialogView : ViewModelViewInject<SettingsDialogViewModel>
    {
        [SerializeField] private TMP_InputField _userNameTextInput;
        [SerializeField] private ViewModelCommandButton _saveNameButton;
        [SerializeField] private Toggle _muteSoundToggle;

        protected override void OnInitializing()
        {
            _userNameTextInput.onValueChanged.AddListener(UpdateUserName);
            _muteSoundToggle.onValueChanged.AddListener(UpdateSoundMuted);
            _saveNameButton.Setup(ViewModel.SaveNameCommand);
            _userNameTextInput.text = ViewModel.UserName;
            _muteSoundToggle.isOn = ViewModel.MuteSound;
        }

        protected override void OnDisposing()
        {
            _userNameTextInput.onValueChanged.RemoveAllListeners();
            _muteSoundToggle.onValueChanged.RemoveAllListeners();
            _saveNameButton.Dispose();
        }

        private void UpdateSoundMuted(bool value)
        {
            ViewModel.MuteSound.Value = value;
        }

        private void UpdateUserName(string userName)
        {
            ViewModel.UserName.Value = userName;
        }
    }
}
