﻿using PhlegmaticOne.DataStorage.KeyResolvers.Base;

namespace PhlegmaticOne.DataStorage.KeyResolvers {
    internal sealed class TypeNameKeyResolver : IKeyResolver {
        public string ResolveKey<T>() => typeof(T).Name;
    }
}