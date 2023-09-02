using PhlegmaticOne.DataStorage.DataSources.Base;
using PhlegmaticOne.DataStorage.DataSources.FirebaseSource.KeyResolvers;
using PhlegmaticOne.DataStorage.DataSources.FirebaseSource.Options;
using PhlegmaticOne.DataStorage.KeyResolvers.Base;

namespace PhlegmaticOne.DataStorage.DataSources.FirebaseSource.Factory {
    internal sealed class DataSourceFactoryFirebase : IDataSourceFactory {
        private readonly IKeyResolver _keyResolver;
        private readonly FirebaseSourceOptions _options;

        public DataSourceFactoryFirebase(IKeyResolver keyResolver, FirebaseSourceOptions options) {
            _keyResolver = keyResolver;
            _options = options;
        }
        
        public DataSourceBase<T> CreateDataSource<T>() {
            var keyResolver = new FirebaseKeyResolver(_keyResolver, _options);
            return new FirebaseDataSource<T>(keyResolver);
        }
    }
}