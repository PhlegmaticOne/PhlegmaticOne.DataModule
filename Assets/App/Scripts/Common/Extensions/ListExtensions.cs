using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Common.Extensions {
    public static class ListExtensions {
        public static T GetRandomItem<T>(this List<T> items) {
            var rnd = Random.Range(0, items.Count);
            return items[rnd];
        }
    }
}