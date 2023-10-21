using UnityEngine;

namespace App.Scripts.Game.Features.BoardState.Configs {
    
    public class BoardStateCheckMinPointMarker : MonoBehaviour, IBoardStateCheckMinPoint {
        public float DestroyBlocksY => transform.position.y;
    }
}