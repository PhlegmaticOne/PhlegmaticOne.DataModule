using App.Scripts.Game.Features.Win.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Filters;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using App.Scripts.Game.States;
using UnityEngine;

namespace App.Scripts.Game.Features.Win.Systems {
    public class SystemWin : SystemBase {
        private readonly StateEndGame _stateEndGame;

        public static bool IsWin;

        private IComponentsFilter _filter;

        public SystemWin(StateEndGame stateEndGame)
        {
            _stateEndGame = stateEndGame;
        }
        
        public override void OnAwake() {
            _filter = ComponentsFilter.Builder
                .With<ComponentLocalWin>()
                .Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter.Apply(World)) {
                _ = _stateEndGame.EnterWin();
                IsWin = true;
                Debug.Log("Win");
                entity.RemoveEndOfFrame();
            }
        }
    }
}