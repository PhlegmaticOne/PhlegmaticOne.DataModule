using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Assets.App.Scripts.Shared.Network;
using Newtonsoft.Json;
using PhlegmaticOne.FruitNinja.Server.Messages.Clients;
using PhlegmaticOne.FruitNinja.Shared;
using Telepathy;
using UnityEngine;
using ILogger = PhlegmaticOne.Logger.Base.ILogger;

namespace App.Scripts.Game.Infrastructure.Session {
    public class NetworkSession : INetworkSession {
        private static readonly JsonSerializerSettings Settings = new()
        {
            TypeNameHandling = TypeNameHandling.Objects
        };
        
        private static readonly byte[] SyncStart = Encoding.UTF8.GetBytes("[SYNC]");
        private static readonly byte[] GameType = Encoding.UTF8.GetBytes("[GAMETYPE]");
        private static readonly byte[] EndGame = Encoding.UTF8.GetBytes("[ENDGAME]");
        private static readonly byte[] EndSync = Encoding.UTF8.GetBytes("[ENDSYNC]");

        private readonly NetworkClientConfig _config;
        private readonly INetworkDataProvider _networkDataProvider;
        private readonly ILogger _logger;

        private TaskCompletionSource<bool> _connectionsCompletionSource;
        private TaskCompletionSource<GameDataBase> _gameDataCompletionSource;
        private TaskCompletionSource<PlayersSyncMessage> _playersSyncMessageCompletionSource;
        
        private CancellationTokenSource _cancellationTokenSource;
        private Client _client;

        public NetworkSession(NetworkClientConfig clientConfig, INetworkDataProvider networkDataProvider, ILogger logger) {
            _config = clientConfig;
            _networkDataProvider=networkDataProvider;
            _logger = logger;
        }
        
        public event Action<ArraySegment<byte>> DataReceived;
        public event Action<PlayerEndGameMessage> EndGameMessageReceived;

        public Task StartAsync() {
            var data = _networkDataProvider.NetworkData;
            Application.runInBackground = true;
            _client = new Client(_config.MaxMessageSize);
            _client.OnConnected += OnConnected;
            _client.OnDisconnected += OnDisconnected;
            _client.OnData += OnData;
            _connectionsCompletionSource = new TaskCompletionSource<bool>();
            _cancellationTokenSource = new CancellationTokenSource();
            _client.Connect(data.Address, data.Port);
            ListenMessages(_cancellationTokenSource.Token);
            return data.TestNotConnect ? Task.CompletedTask : _connectionsCompletionSource.Task;
        }

        public Task<GameDataBase> ReceiveGameDataAsync()
        {
            if(_networkDataProvider.NetworkData.TestNotConnect)
            {
                return Task.FromResult(new GameDataByLifes
                {
                    LifesCount = 3,
                    GameModeType = GameModeType.ByLifes
                } as GameDataBase);
            }

            _gameDataCompletionSource = new TaskCompletionSource<GameDataBase>();
            _cancellationTokenSource = new CancellationTokenSource();
            ListenMessages(_cancellationTokenSource.Token);
            return _gameDataCompletionSource.Task;
        }

        public Task<PlayersSyncMessage> ReceiveSyncMessageAsync()
        {
            _playersSyncMessageCompletionSource = new TaskCompletionSource<PlayersSyncMessage>();
            _cancellationTokenSource = new CancellationTokenSource();
            ListenMessages(_cancellationTokenSource.Token);
            return _playersSyncMessageCompletionSource.Task;
        }

        public void Tick() {
            _client.Tick(_config.ProcessLimit);
        }

        public void SendMessage(ArraySegment<byte> message) {
            _client.Send(message);
        }

        public void Dispose() {
            _client.OnConnected -= OnConnected;
            _client.OnDisconnected -= OnDisconnected;
            _client.OnData -= OnData;
            _client.Disconnect();
        }

        private void OnData(ArraySegment<byte> message) {
            if (IsMessageOfType(message, SyncStart))
            {
                var clientsCountMessage = ParseObjectFromMessage<ClientsConnectedMessage>(message, SyncStart.Length);
                UpdateWaitingState(clientsCountMessage.ClientsConnected);
                return;
            }

            if (IsMessageOfType(message, GameType))
            {
                var gameTypeJson = ParseObjectFromMessage<GameDataBase>(message, GameType.Length, true);
                _gameDataCompletionSource.TrySetResult(gameTypeJson);
                return;
            }
            
            if (IsMessageOfType(message, EndGame))
            {
                var gameTypeJson = ParseObjectFromMessage<PlayerEndGameMessage>(message, EndGame.Length);
                EndGameMessageReceived?.Invoke(gameTypeJson);
                return;
            }
            
            if (IsMessageOfType(message, EndSync))
            {
                var gameTypeJson = ParseObjectFromMessage<PlayersSyncMessage>(message, EndSync.Length);
                _playersSyncMessageCompletionSource.TrySetResult(gameTypeJson);
                return;
            }

            DataReceived?.Invoke(message);
        }

        private void OnDisconnected() {
            _logger.LogMessage("Disconnected");
        }

        private void OnConnected() {
            _logger.LogMessage("Connected");
        }

        private async Task ListenMessages(CancellationToken cancellationToken) {
            while (_cancellationTokenSource.IsCancellationRequested == false) {
                await Task.Delay(20, cancellationToken);
                Tick();
            }
            
            _logger.LogMessage("Exiting ListenConnections");
        }

        private void UpdateWaitingState(int clientsCount) {
            if (clientsCount == _config.ClientsCount) {
                _cancellationTokenSource.Cancel();
                _connectionsCompletionSource.SetResult(true);
            }
        }

        private static T ParseObjectFromMessage<T>(ArraySegment<byte> message, int start, bool useSettings = false) where T : class
        {
            var messageBytes = message[new Range(new Index(start), new Index(0, true))];
            var messageJson = Encoding.UTF8.GetString(messageBytes);
            var settings = useSettings ? Settings : null;
            return JsonConvert.DeserializeObject<T>(messageJson, settings);
        }

        private static bool IsMessageOfType(ArraySegment<byte> message, byte[] messageType) {
            for (var i = 0; i < messageType.Length; i++) {
                if (messageType[i] != message.get_Item(i)) {
                    return false;
                }
            }

            return true;
        }
    }
}