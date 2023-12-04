using PhlegmaticOne.FruitNinja.Shared;

namespace App.Scripts.Game.Modes.Base
{
    public interface IGameMode
    {
        GameModeType GameModeType { get; }
        bool IsBreakGame { get; }
        void ApplyData(GameDataBase gameDataBase);
        bool IsLocalCompleted();
        GameEndStateViewModel BuildGameEndStateViewModel(PlayersSyncMessage playersSyncMessage);
    }
}