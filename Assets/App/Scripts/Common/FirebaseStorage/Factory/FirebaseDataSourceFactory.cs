using App.Scripts.Common.FirebaseStorage.KeyResolvers;
using PhlegmaticOne.DataStorage.Contracts;
using PhlegmaticOne.DataStorage.DataSources.Base;
using PhlegmaticOne.DataStorage.KeyResolvers.Base;

namespace App.Scripts.Common.FirebaseStorage.Factory
{
    public class FirebaseDataSourceFactory : IDataSourceFactory
    {
        private readonly IKeyResolver _keyResolver;

        public FirebaseDataSourceFactory(IKeyResolver keyResolver) {
            _keyResolver = keyResolver;
        }
        
        public DataSourceBase<T> CreateDataSource<T>() where T : class, IModel {
            var keyResolver = new FirebaseKeyResolver(_keyResolver);
            return new FirebaseDataSource<T>(keyResolver);
        }
    }
}