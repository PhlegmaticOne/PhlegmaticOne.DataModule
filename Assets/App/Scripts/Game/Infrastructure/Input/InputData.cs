using System;
using App.Scripts.Game.Infrastructure.Serialization;
using Newtonsoft.Json;
using UnityEngine;

namespace App.Scripts.Game.Infrastructure.Input {
    [Serializable]
    public struct InputData {
        public static InputData Invalid => new(Vector3.zero, InputState.None, false);
        
        [JsonConstructor]
        public InputData(Vector3 position, InputState inputState, bool isValid)
        {
            Position = position;
            InputState = inputState;
            IsValid = isValid;
        }

        [JsonProperty]
        public Vector3Tiny Position { get; }
        [JsonProperty]
        public InputState InputState { get; }
        [JsonProperty]
        public bool IsValid { get; }
    }
}