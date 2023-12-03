using App.Scripts.Common.ViewModels;
using Assets.App.Scripts.Menu.Features.Connect.ViewModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConnectDialogView : ViewModelViewInject<ConnectDialogViewModel>
{
    [SerializeField] private TMP_InputField _addressInput;
    [SerializeField] private TMP_InputField _portInput;
    [SerializeField] private Toggle _testNotConnectToggle;
    [SerializeField] private ViewModelCommandButton _submitButton;

    protected override void OnInitializing()
    {
        _addressInput.text = ViewModel.Address;
        _portInput.text = ViewModel.Port.Value.ToString();
        _testNotConnectToggle.SetIsOnWithoutNotify(ViewModel.TestNotConnect);
        _submitButton.Setup(ViewModel.SubmitCommand);

        _addressInput.onValueChanged.AddListener(UpdateAddress);
        _portInput.onValueChanged.AddListener(UpdatePort);
        _testNotConnectToggle.onValueChanged.AddListener(UpdateTestNotConnect);
    }

    public override void Dispose()
    {
        _submitButton.Dispose();
        _addressInput.onValueChanged.RemoveAllListeners();
        _portInput.onValueChanged.RemoveAllListeners();
        _testNotConnectToggle.onValueChanged.RemoveAllListeners();
    }

    private void UpdateAddress(string address)
    {
        ViewModel.Address.Value = address;
    }

    private void UpdatePort(string port)
    {
        ViewModel.Port.Value = int.Parse(port);
    }

    private void UpdateTestNotConnect(bool testNotConnect)
    {
        ViewModel.TestNotConnect.Value = testNotConnect;
    }
}
