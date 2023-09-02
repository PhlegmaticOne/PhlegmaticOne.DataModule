using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace App.Scripts.Menu.Features.Statistics.Models {
    [Serializable]
    [DataContract]
    public class StatisticsBlockInfo {
        [JsonConstructor]
        public StatisticsBlockInfo(StatisticsBlockType blockType, int slicesCount) {
            BlockType = blockType;
            SlicesCount = slicesCount;
        }

        public static StatisticsBlockInfo Zero(StatisticsBlockType blockType) => new(blockType, 0);
        
        [DataMember(Name = "type")]
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public StatisticsBlockType BlockType { get; private set; }
        
        [DataMember(Name = "c")] 
        [JsonProperty("c")]
        public int SlicesCount { get; private set; }

        public int AddSlice() => ++SlicesCount;
    }
}