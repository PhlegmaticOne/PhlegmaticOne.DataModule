using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace App.Scripts.Game {
    [Serializable]
    public class GameState {
        [JsonProperty("game_commands")] private List<string> _commands;

        [JsonConstructor]
        public GameState(List<string> commands) {
            _commands = commands;
        }

        public IReadOnlyList<string> GetCommands() {
            return _commands;
        }
    }
}