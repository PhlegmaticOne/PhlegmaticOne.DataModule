using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace App.Scripts.Menu.Features.Progress.Models {
    [Serializable]
    [DataContract]
    public class PlayerProgress {
        
        [JsonConstructor]
        public PlayerProgress(int maxScore, int coinsCount) {
            MaxScore = maxScore;
            CoinsCount = coinsCount;
        }

        public static PlayerProgress Zero => new(0, 0);

        [DataMember]
        public int MaxScore { get; private set; }
        
        [DataMember]
        public int CoinsCount { get; private set; }

        public void ChangeScore(int maxScore) {
            if (maxScore < 0) {
                throw new ArgumentException("Max score cannot be less than 0", nameof(maxScore));
            }
            
            MaxScore = maxScore;
        }
        
        public void ChangeCoins(int coins) {
            if (coins < 0) {
                throw new ArgumentException("CoinsCount cannot be less or than 0", nameof(coins));
            }
            
            CoinsCount = coins;
        }
    }
}