using UnityEngine;

namespace App.Scripts.Game.Infrastructure.Session {
    [CreateAssetMenu(fileName = "NetworkClientConfig", menuName = "Game/Network/Config")]
    public class NetworkClientConfig : ScriptableObject {
        [SerializeField] private string _serverAddress;
        [SerializeField] private int _serverPort;
        [SerializeField] private int _maxMessageSize;
        [SerializeField] private int _processLimit;
        [SerializeField] private bool _testNotConnect;

        public string ServerAddress => _serverAddress;
        public int ServerPort => _serverPort;
        public int MaxMessageSize => _maxMessageSize;
        public int ProcessLimit => _processLimit;
        public bool TestNotConnect => _testNotConnect;
    }
}