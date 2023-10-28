using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using PhlegmaticOne.DataStorage.Contracts;

namespace App.Scripts.Shared.Progress.Models {
    [Serializable]
    [DataContract]
    public class PlayerProgress : IModel {
        
        [JsonConstructor]
        public PlayerProgress(int maxScore) {
            MaxScore = maxScore;
        }

        public static PlayerProgress Zero => new(0);

        [DataMember]
        public int MaxScore { get; private set; }

        public void ChangeMaxScore(int maxScore) {
            if (maxScore < 0) {
                throw new ArgumentException("Max score cannot be less than 0", nameof(maxScore));
            }
            
            MaxScore = maxScore;
        }
    }
}