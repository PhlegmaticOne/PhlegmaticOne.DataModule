using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.Auth.Assets.App.Modules.Auth.EmailPassword
{
    public class EmailPasswordAuthWindow : MonoBehaviour, IAuthSource
    {
        [SerializeField] private TMP_InputField _emailText;
        [SerializeField] private TMP_InputField _passwordText;
        [SerializeField] private Toggle _isSignIn;
        [SerializeField] private Toggle _isSignUp;
        [SerializeField] private Button _processButton;

        private TaskCompletionSource<AuthData> _result;

        public void SetRawData(string email, string password)
        {
            _emailText.text = email;
            _passwordText.text = password;
        }

        public Task<AuthData> GetAuthDataAsync()
        {
            gameObject.SetActive(true);
            _result = new TaskCompletionSource<AuthData>();
            _processButton.onClick.AddListener(Process);
            _isSignIn.onValueChanged.AddListener(ProcessAuthenticationType);
            _isSignUp.onValueChanged.AddListener(ProcessAuthenticationType);
            _isSignIn.SetIsOnWithoutNotify(true);
            _isSignUp.SetIsOnWithoutNotify(false);
            return _result.Task;
        }

        private void ProcessAuthenticationType(bool _)
        {
            if(_isSignIn.isOn)
            {
                _isSignIn.SetIsOnWithoutNotify(false);
                _isSignUp.SetIsOnWithoutNotify(true);
            }
            else
            {
                _isSignIn.SetIsOnWithoutNotify(true);
                _isSignUp.SetIsOnWithoutNotify(false);
            }
        }

        private void Process()
        {
            _processButton.onClick.RemoveAllListeners();
            _isSignUp.onValueChanged.RemoveAllListeners();
            _isSignUp.onValueChanged.RemoveAllListeners();
            var email = _emailText.text;
            var password = _passwordText.text;
            var isSignIn = _isSignIn.isOn;
            var authData = new AuthData(email, password, isSignIn);
            _result.TrySetResult(authData);
            gameObject.SetActive(false);
        }
    }
}
