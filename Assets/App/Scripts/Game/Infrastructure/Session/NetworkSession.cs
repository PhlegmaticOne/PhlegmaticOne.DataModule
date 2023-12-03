using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Assets.App.Scripts.Shared.Network;
using Newtonsoft.Json;
using Telepathy;
using UnityEngine;
using ILogger = PhlegmaticOne.Logger.Base.ILogger;

namespace App.Scripts.Game.Infrastructure.Session {
    public class NetworkSession : INetworkSession {
        private static readonly byte[] SyncStart = Encoding.UTF8.GetBytes("[SYNC]");

        private readonly NetworkClientConfig _config;
        private readonly INetworkDataProvider _networkDataProvider;
        private readonly ILogger _logger;

        private TaskCompletionSource<bool> _completionSource;
        private CancellationTokenSource _cancellationTokenSource;
        private Client _client;

        public NetworkSession(NetworkClientConfig clientConfig, INetworkDataProvider networkDataProvider, ILogger logger) {
            _config = clientConfig;
            _networkDataProvider=networkDataProvider;
            _logger = logger;
        }
        
        public event Action Disconnected;
        
        public event Action<ArraySegment<byte>> DataReceived;
        
        public Task StartAsync() {
            var data = _networkDataProvider.NetworkData;
            Application.runInBackground = true;
            _client = new Client(_config.MaxMessageSize);
            _client.OnConnected += OnConnected;
            _client.OnDisconnected += OnDisconnected;
            _client.OnData += OnData;
            _completionSource = new TaskCompletionSource<bool>();
            _cancellationTokenSource = new CancellationTokenSource();
            _client.Connect(data.Address, data.Port);
            ListenConnections(_cancellationTokenSource.Token);
            return data.TestNotConnect ? Task.CompletedTask : _completionSource.Task;
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
            if (IsSyncMessage(message)) {
                var messageBytes = message[new Range(new Index(SyncStart.Length), new Index(0, true))];
                var messageJson = Encoding.UTF8.GetString(messageBytes);
                var clientsConnected = JsonConvert.DeserializeObject<ClientsCountMessage>(messageJson);
                UpdateWaitingState(clientsConnected.ClientsConnected);
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

        private async Task ListenConnections(CancellationToken cancellationToken) {
            while (_cancellationTokenSource.IsCancellationRequested == false) {
                await Task.Delay(20, cancellationToken);
                Tick();
            }
            
            _logger.LogMessage("Exiting ListenConnections");
        }

        private void UpdateWaitingState(int clientsCount) {
            if (clientsCount == _config.ClientsCount) {
                _cancellationTokenSource.Cancel();
                _completionSource.SetResult(true);
            }
        }

        private static bool IsSyncMessage(ArraySegment<byte> message) {
            for (var i = 0; i < SyncStart.Length; i++) {
                if (SyncStart[i] != message.get_Item(i)) {
                    return false;
                }
            }

            return true;
        }
    }
}