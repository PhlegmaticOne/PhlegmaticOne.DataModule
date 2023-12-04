using App.Scripts.Shared.Progress.Services;
using PhlegmaticOne.FruitNinja.Shared;
using TMPro;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Modes.Base
{
    public abstract class GameModeBase<T> : MonoBehaviour, IGameMode where T : GameDataBase
    {
        [SerializeField] private TextMeshProUGUI _otherPlayerText;
        [SerializeField] private TextMeshProUGUI _currentPlayerText;
        
        protected T GameDataBase;
        protected IPlayerService PlayerService;

        [Inject]
        private void Construct(IPlayerService playerService)
        {
            PlayerService = playerService;
        }
        
        public abstract GameModeType GameModeType { get; }
        public abstract bool IsBreakGame { get; }

        public void ApplyData(GameDataBase gameDataBase)
        {
            _currentPlayerText.text = PlayerService.UserName;
            
            if (gameDataBase is T generic)
            {
                GameDataBase = generic;
                ApplyReceivedData();
            }
        }

        public abstract bool IsLocalCompleted();

        public abstract GameEndStateViewModel BuildGameEndStateViewModel(PlayersSyncMessage playersSyncMessage);
        protected virtual void ApplyReceivedData() { }
    }
}