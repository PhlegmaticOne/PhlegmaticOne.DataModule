using App.Scripts.Common.Scenes.Base;
using App.Scripts.Game.Features.Win.Components;
using App.Scripts.Game.Infrastructure.Ecs.Worlds;
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

        [Inject]
        private void Construct(ISceneProvider sceneProvider) {
            _sceneProvider = sceneProvider;
        }

        public void ShowScreen(ComponentWin componentWin) {
            gameObject.SetActive(true);
            _scoreText.text = componentWin.Score.ToString();
            _playerNameText.text = componentWin.PlayerName;
            _exitButton.onClick.AddListener(Exit);
        }

        private async void Exit() {
            await _sceneProvider.LoadSceneAsync(SceneType.Menu);
        }
    }
}