using App.Scripts.Common.Input.Base;
using App.Scripts.Common.Scenes.Base;
using App.Scripts.Game.Modes.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Scripts.Game.Features.Win.Views {
    public class FinalScreenView : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _scoreTextLoser;
        [SerializeField] private TextMeshProUGUI _playerNameTextLoser;
        [SerializeField] private TextMeshProUGUI _scoreTextWinner;
        [SerializeField] private TextMeshProUGUI _playerNameTextWinner;
        [SerializeField] private GameObject _isDrawObject;
        [SerializeField] private GameObject[] _textsObjects;
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
            _scoreTextLoser.text = viewModel.Loser.Score.ToString();
            _playerNameTextLoser.text = viewModel.Loser.UserName;

            _scoreTextWinner.text = viewModel.Winner.Score.ToString();
            _playerNameTextWinner.text = viewModel.Winner.UserName;
            
            _isDrawObject.SetActive(viewModel.IsDraw);
            
            foreach (var textsObject in _textsObjects)
            {
                textsObject.SetActive(!viewModel.IsDraw);
            }
            
            _inputLocker.Unlock();
        }

        private async void Exit() {
            await _sceneProvider.LoadSceneAsync(SceneType.Menu);
        }
    }
}