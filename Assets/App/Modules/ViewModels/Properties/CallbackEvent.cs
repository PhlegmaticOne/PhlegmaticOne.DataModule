using System;
using System.Collections.Generic;

namespace PhlegmaticOne.ViewModels.Properties {
    public class CallbackEvent {
        private readonly List<Action> _actions;

        public CallbackEvent() => _actions = new List<Action>();

        public void AddListener(Action action) {
            _actions.Add(action);
        }

        public void RemoveListener(Action action) {
            _actions.Remove(action);
        }

        public void RemoveAllListeners() {
            _actions.Clear();
        }

        public void Invoke() {
            foreach (var action in _actions) {
                action?.Invoke();
            }
        }
    }
}