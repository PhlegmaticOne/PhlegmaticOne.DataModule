using System.Collections.Generic;
using System.Linq;

namespace App.Scripts.Game.Infrastructure.Random {
    public static class PriorityExtensions {
        public static T GetRandomItemBasedOnProbabilities<T>(this List<T> items) where T : IPrioritized {
            var prioritiesSum = items.Sum(x => x.Priority);
            var randomCumulativeProbability = UnityEngine.Random.Range(0, prioritiesSum);
            var cumulativeSum = 0f;
            
            foreach (var spawnerInfo in items) {
                cumulativeSum += spawnerInfo.Priority;
                if (randomCumulativeProbability < cumulativeSum) {
                    return spawnerInfo;
                }
            }

            return items.LastOrDefault();
        }
    }
}