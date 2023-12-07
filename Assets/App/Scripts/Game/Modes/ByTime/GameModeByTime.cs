using App.Scripts.Game.Modes.Base;
using PhlegmaticOne.FruitNinja.Shared;
using TMPro;
using UnityEngine;

namespace App.Scripts.Game.Modes.ByTime
{
    public class GameModeByTime : GameModeBase<GameDataByTime>
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        
        private float _playTime;
        private float _currentTime;
        
        public override GameModeType GameModeType => GameModeType.ByTime;
        public override bool IsBreakGame => false;

        private void Update()
        {
            if (_currentTime >= _playTime)
            {
                return;
            }
            
            _currentTime += Time.deltaTime;
            _timerText.text = ((int)(_playTime - _currentTime)).ToString();
        }

        public override bool IsLocalCompleted() => _currentTime >= _playTime;

        public override GameEndStateViewModel BuildGameEndStateViewModel(PlayersSyncMessage playersSyncMessage)
        {
            return new GameEndStateViewModel(PlayerService).SetDefaultsFromPlayers(playersSyncMessage);
        }

        protected override void ApplyReceivedData()
        {
            _timerText.gameObject.SetActive(true);
            _playTime = GameDataBase.PlayTime;
        }
    }
}