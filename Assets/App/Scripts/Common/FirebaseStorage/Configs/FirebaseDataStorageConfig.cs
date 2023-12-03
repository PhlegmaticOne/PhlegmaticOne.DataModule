using App.Scripts.Common.FirebaseStorage.Factory;
using PhlegmaticOne.DataStorage.Configuration.DataSources;
using PhlegmaticOne.DataStorage.Configuration.KeyResolvers;
using PhlegmaticOne.DataStorage.DataSources.Base;
using UnityEngine;

namespace App.Scripts.Common.FirebaseStorage.Configs
{
    [CreateAssetMenu(menuName = "Data Storage/Storages/Firebase", fileName = "FirebaseConfigDataStorage")]
    public class FirebaseDataStorageConfig : DataStorageConfigBase
    {
        [SerializeField] private DataStorageKeyResolverConfigurationBase _keyResolver;
        
        public override IDataSourceFactory GetSourceFactory()
        {
            return new FirebaseDataSourceFactory(_keyResolver.GetKeyResolver());
        }
    }
}