using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Scripts.Common.Utils {
    public static class EnumUtils {
        public static IEnumerable<T> Values<T>() where T : Enum {
            return Enum.GetValues(typeof(T)).OfType<T>();
        }
    }
}