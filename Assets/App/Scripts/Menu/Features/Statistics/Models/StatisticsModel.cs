using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using App.Scripts.Common.Utils;
using Newtonsoft.Json;

namespace App.Scripts.Menu.Features.Statistics.Models {
    [Serializable]
    [DataContract]
    public class StatisticsModel {
        [DataMember]
        private List<StatisticsBlockInfo> _statistics;

        public static StatisticsModel Initial {
            get {
                var statisticsEntries = EnumUtils
                    .Values<StatisticsBlockType>()
                    .Select(StatisticsBlockInfo.Zero)
                    .ToList();
                return new StatisticsModel(statisticsEntries);
            }
        }

        [JsonConstructor]
        public StatisticsModel(List<StatisticsBlockInfo> statistics) {
            _statistics = statistics;
        }

        public IReadOnlyList<StatisticsBlockInfo> Statistics => _statistics;

        public StatisticsBlockInfo AddSlice(StatisticsBlockType blockType) {
            var info = _statistics.FirstOrDefault(x => x.BlockType == blockType);
            info?.AddSlice();
            return info;
        }
    }
}