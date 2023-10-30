using System;
using Newtonsoft.Json;

namespace App.Scripts.Game.Infrastructure.Session {
    [Serializable]
    public class ClientsCountMessage {
        
        [JsonConstructor]
        public ClientsCountMessage(int clientsConnected) => ClientsConnected = clientsConnected;
        public int ClientsConnected { get; }
    }
}