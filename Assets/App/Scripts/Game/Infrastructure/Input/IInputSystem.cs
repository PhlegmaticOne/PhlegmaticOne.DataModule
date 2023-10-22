using UnityEngine;
using UnityEngine.Events;

namespace App.Scripts.Game.Infrastructure.Input {
    public interface IInputSystem {
        event UnityAction Began;
        event UnityAction Ended;
        event UnityAction<Vector3> Moved; 
        bool IsValid { get; }
        InputData ReadInput();
        void MakeInvalid();
        void Reset();
    }
}