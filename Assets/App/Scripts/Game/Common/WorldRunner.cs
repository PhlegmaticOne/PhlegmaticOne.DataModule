using System;
using System.Collections.Generic;
using App.Scripts.Game.Infrastructure.Ecs;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Common {
    public class WorldRunner : MonoBehaviour {
        private World _world;
        
        [Inject]
        private void Construct(IEnumerable<ISystem> systems) {
            _world = new World(systems);
        }

        private void Awake() {
            _world.Construct();
        }

        private void Update() {
            _world.Update(Time.deltaTime);
        }

        private void FixedUpdate() {
            _world.FixedUpdate(Time.fixedDeltaTime);
        }
    }
}