using App.Scripts.Game.States;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Features._Start {
    public class Bootstrap : MonoBehaviour, IInitializable {
        private StateStartGame _stateStartGame;

        [Inject]
        private void Construct(StateStartGame stateStartGame) {
            _stateStartGame = stateStartGame;
        }
        
        public async void Initialize() {
            await _stateStartGame.Enter();
        }
    }
}