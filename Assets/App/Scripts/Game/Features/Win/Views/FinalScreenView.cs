using App.Scripts.Common.Input.Base;
using App.Scripts.Common.Scenes.Base;
using App.Scripts.Game.Modes.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Scripts.Game.Features.Win.Views {
    public class FinalScreenView : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _playerNameText;
        [SerializeField] private Button _exitButton;
        
        private ISceneProvider _sceneProvider;
        private IInputLocker _inputLocker;

        [Inject]
        private void Construct(ISceneProvider sceneProvider, IInputLocker inputLocker)
        {
            _inputLocker = inputLocker;
            _sceneProvider = sceneProvider;
        }

        public void ShowScreenLoading() {
            _inputLocker.Lock();
            gameObject.SetActive(true);
            _exitButton.onClick.AddListener(Exit);
        }
        
        public void ShowGameResult(GameEndStateViewModel viewModel)
        {
            _scoreText.text = viewModel.Winner.Score.ToString();
            _playerNameText.text = viewModel.Winner.UserName;
            _inputLocker.Unlock();
        }

        private async void Exit() {
            await _sceneProvider.LoadSceneAsync(SceneType.Menu);
        }
    }
}