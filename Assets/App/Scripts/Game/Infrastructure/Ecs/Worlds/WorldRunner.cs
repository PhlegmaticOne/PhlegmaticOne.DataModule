using System.Collections.Generic;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Infrastructure.Ecs.Worlds {
    public class WorldRunner : MonoBehaviour {
        [SerializeField] private bool _isRunGame;
        
        private World _world;

        [Inject]
        private void Construct(World world, IEnumerable<ISystem> systems) {
            _world = world;
            _world.Initialize(systems);
        }

        private void Awake() {
            if (!_isRunGame) {
                return;
            }
            
            _world.Construct();
        }

        private void Update() {
            if (!_isRunGame) {
                return;
            }
            
            _world.Update(Time.deltaTime);
        }

        private void FixedUpdate() {
            if (!_isRunGame) {
                return;
            }
            
            _world.FixedUpdate(Time.fixedDeltaTime);
        }

        private void OnApplicationQuit() {
            if (!_isRunGame) {
                return;
            }
            
            _world.Dispose();
        }
    }
}