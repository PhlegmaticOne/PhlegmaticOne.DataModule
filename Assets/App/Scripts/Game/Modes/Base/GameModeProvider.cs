using System.Collections.Generic;
using System.Linq;
using PhlegmaticOne.FruitNinja.Shared;

namespace App.Scripts.Game.Modes.Base
{
    public class GameModeProvider : IGameModeProvider
    {
        private readonly Dictionary<GameModeType, IGameMode> _gameModes;
        private IGameMode _currentGameMode;

        public GameModeProvider(IEnumerable<IGameMode> gameModes)
        {
            _gameModes = gameModes.ToDictionary(x => x.GameModeType, x => x);
        }

        public GameModeType GameModeType => _currentGameMode.GameModeType;

        public void ApplyGameMode(GameDataBase gameDataBase)
        {
            _currentGameMode = _gameModes[gameDataBase.GameModeType];
            _currentGameMode.ApplyData(gameDataBase);
        }

        public bool IsCurrentCompleted()
        {
            return _currentGameMode.IsLocalCompleted();
        }

        public GameEndStateViewModel BuildGameEndState(PlayersSyncMessage endGameMessage)
        {
            return _currentGameMode.BuildGameEndStateViewModel(endGameMessage);
        }

        public bool IsBreakGame()
        {
            return _currentGameMode.IsBreakGame;
        }
    }
}