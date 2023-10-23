using System.Collections.Generic;
using System.Linq;

namespace App.Scripts.Game.Infrastructure.Random {
    public struct PrioritizedKeyValuePair<TKey, TValue> : IPrioritized where TValue : IPrioritized {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public float Priority => Value.Priority;
    }
    
    public static class PriorityExtensions {
        public static T GetRandomItemBasedOnProbabilities<T>(this IReadOnlyCollection<T> items) where T : IPrioritized {
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

        public static PrioritizedKeyValuePair<TKey, TValue> GetRandomItemBasedOnProbabilities<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary) 
            where TValue : IPrioritized 
        {
            var list = dictionary.Select(x => new PrioritizedKeyValuePair<TKey, TValue> {
                Key = x.Key,
                Value = x.Value
            }).ToArray();
            return GetRandomItemBasedOnProbabilities(list);
        }
    }
}