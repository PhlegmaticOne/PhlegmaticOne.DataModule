using App.Scripts.Game.Features.BoardState.Configs;
using UnityEngine;
using Zenject;

namespace App.Scripts.Game.Features.BoardState.Installer {
    public class BoardStateCheckInstaller : MonoInstaller {
        [SerializeField] private BoardStateCheckMinPointMarker _minPointMarker;
        
        public override void InstallBindings() {
            Container.Bind<IBoardStateCheckMinPoint>().FromInstance(_minPointMarker).AsSingle();
        }
    }
}