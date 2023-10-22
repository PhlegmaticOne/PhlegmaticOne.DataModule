using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using App.Scripts.Game.Features.Network.Configs;
using App.Scripts.Game.Features.Network.Services;
using App.Scripts.Game.Infrastructure.Ecs.Components;
using App.Scripts.Game.Infrastructure.Ecs.Entities;
using App.Scripts.Game.Infrastructure.Ecs.Systems;
using Telepathy;
using UnityEngine;
using ILogger = PhlegmaticOne.Logger.Base.ILogger;

namespace App.Scripts.Game.Features.Network.Systems {
    public class SystemNetwork : SystemBase {
        private readonly Client _client;
        private readonly NetworkClientConfig _config;
        private readonly ILogger _logger;
        private readonly INetworkService _networkService;

        private ConcurrentBag<Entity> _incomeEntities;

        public SystemNetwork(INetworkService networkService, NetworkClientConfig config, ILogger logger) {
            _networkService = networkService;
            _config = config;
            _logger = logger;
            _client = new Client(config.MaxMessageSize);
            _incomeEntities = new ConcurrentBag<Entity>();
        }
        
        public override void OnAwake() {
            Application.runInBackground = true;
            _client.OnConnected += OnConnected;
            _client.OnDisconnected += OnDisconnected;
            _client.OnData += OnData;
            _client.Connect(_config.ServerAddress, _config.ServerPort);
        }

        public override void OnUpdate(float deltaTime) {
            _client.Tick(_config.ProcessLimit);

            if (_networkService.NetworkEntity.ComponentsCount <= 1) {
                return;
            }
            
            var message = _networkService.CreateMessage();
            _client.Send(message);
        }

        public override void OnDispose() {
            _client.OnConnected -= OnConnected;
            _client.OnDisconnected -= OnDisconnected;
            _client.OnData -= OnData;
            _client.Disconnect();
        }

        private void OnData(ArraySegment<byte> message) {
            var entity = _networkService.CreateEntityFromRemoteMessage(message);
            World.AppendEntity(entity).WithComponent(new ComponentRemoveEntityEndOfFrame());
        }

        private void OnConnected() {
            _logger.LogMessage("Client connected!");
        }

        private void OnDisconnected() {
            _logger.LogMessage("Client disconnected!");
        }
    }
}