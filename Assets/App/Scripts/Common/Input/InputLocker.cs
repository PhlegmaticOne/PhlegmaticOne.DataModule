using App.Scripts.Common.Input.Base;
using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Scripts.Common.Input {
    public class InputLocker : MonoBehaviour, IInputLocker {
        [SerializeField] private EventSystem _eventSystem;
        
        public void Lock() => _eventSystem.enabled = false;

        public void Unlock() => _eventSystem.enabled = true;
    }
}