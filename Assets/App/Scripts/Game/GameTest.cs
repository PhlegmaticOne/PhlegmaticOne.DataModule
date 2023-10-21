using System;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace App.Scripts.Game {
    public class GameTest : MonoBehaviour {
        private readonly Telepathy.Client _client = new(16384);

        private void Awake() {
            Application.runInBackground = true;
            _client.OnConnected = () => {
                Debug.Log("Client Connected");
            };
            _client.OnData = message => {
                var str = Encoding.UTF8.GetString(message);
                var value = JsonConvert.DeserializeObject<GameState>(str);
                HandleMessage(value);
            };
            _client.OnDisconnected = () => {
                Debug.Log("Client Disconnected");
            };
        }

        private void Start() {
            _client.Connect("localhost", 8888);
        }

        private void Update() {
            _client.Tick(100);

            if (Input.GetMouseButtonDown(0)) {
                _client.Send(new ArraySegment<byte>(new byte[]{0x1}));
            }
        }

        private void OnApplicationQuit() {
            _client.Disconnect();
        }
        
        private void HandleMessage(GameState gameState) {
            foreach (var command in gameState.GetCommands()) {
                if (command == "Spawn") {
                    Debug.Log("Spawn");
                }
            }
        }
    }
}