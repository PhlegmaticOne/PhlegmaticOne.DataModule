using UnityEngine;

namespace App.Scripts.Game.Infrastructure.Session {
    [CreateAssetMenu(fileName = "NetworkClientConfig", menuName = "Game/Network/Config")]
    public class NetworkClientConfig : ScriptableObject {
        [SerializeField] private int _maxMessageSize;
        [SerializeField] private int _processLimit;
        [SerializeField] private int _clientsCount;

        public int MaxMessageSize => _maxMessageSize;
        public int ProcessLimit => _processLimit;
        public int ClientsCount => _clientsCount;
    }
}