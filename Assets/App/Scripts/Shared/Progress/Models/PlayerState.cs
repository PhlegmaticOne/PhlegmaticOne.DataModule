using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using PhlegmaticOne.DataStorage.Contracts;

namespace App.Scripts.Shared.Progress.Models {
    [Serializable]
    [DataContract]
    public class PlayerState : IModel {
        
        [JsonConstructor]
        public PlayerState(int maxScore, string name) {
            MaxScore = maxScore;
            Name=name;
        }

        public static PlayerState Zero => new(0, string.Empty);

        [DataMember]
        public int MaxScore { get; private set; }
        [DataMember]
        public string Name { get; private set; }

        public void ChangeMaxScore(int maxScore) {
            if (maxScore < 0) {
                throw new ArgumentException("Max score cannot be less than 0", nameof(maxScore));
            }
            
            MaxScore = maxScore;
        }

        public void ChangeName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return;
            }

            Name = name;
        }
    }
}