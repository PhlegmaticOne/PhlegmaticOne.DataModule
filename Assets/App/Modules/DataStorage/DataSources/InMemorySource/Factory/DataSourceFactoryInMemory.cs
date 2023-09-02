using PhlegmaticOne.DataStorage.DataSources.Base;

namespace PhlegmaticOne.DataStorage.DataSources.InMemorySource.Factory {
    internal sealed class DataSourceFactoryInMemory : IDataSourceFactory {
        public DataSourceBase<T> CreateDataSource<T>() => new InMemoryDataSource<T>();
    }
}