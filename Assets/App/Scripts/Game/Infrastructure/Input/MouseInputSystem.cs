using UnityEngine;
using UnityEngine.Events;

namespace App.Scripts.Game.Infrastructure.Input {
    public class MouseInputSystem : IInputSystem {
        public event UnityAction Began;
        public event UnityAction Ended;
        public event UnityAction<Vector3> Moved;

        public bool IsValid { get; private set; } = true;

        public InputData ReadInput() {
            var position = UnityEngine.Input.mousePosition;

            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                OnBegan();
                return IsValid ? new InputData(position, InputState.Started, true) : InputData.Invalid;
            }

            if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                OnEnded();
                return IsValid ? new InputData(position, InputState.Ended, true) : InputData.Invalid;
            }

            if (UnityEngine.Input.GetMouseButton(0))
            {
                OnMoved(position);
                return IsValid ? new InputData(position, InputState.Active, true) : InputData.Invalid;
            }

            return InputData.Invalid;
        }

        private void OnBegan() => Began?.Invoke();
        private void OnEnded() => Ended?.Invoke();
        private void OnMoved(Vector3 position) => Moved?.Invoke(position);

        public void MakeInvalid() => IsValid = false;
        public void Reset() => IsValid = true;
    }
}