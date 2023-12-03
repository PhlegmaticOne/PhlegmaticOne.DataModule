using System.Threading;
using System.Threading.Tasks;
using Firebase.Database;
using Newtonsoft.Json;
using PhlegmaticOne.DataStorage.Contracts;
using PhlegmaticOne.DataStorage.DataSources.Base;
using PhlegmaticOne.DataStorage.KeyResolvers.Base;

namespace App.Scripts.Common.FirebaseStorage
{
    public class FirebaseDataSource<T> : DataSourceBase<T> where T : class, IModel
    {
        private readonly string _referencePath;
        private readonly DatabaseReference _reference;

        public FirebaseDataSource(IKeyResolver keyResolver) {
            _reference = FirebaseDatabase.DefaultInstance.RootReference;
            _referencePath = keyResolver.ResolveKey<T>();
        }

        protected override Task WriteAsync(T value, CancellationToken cancellationToken = default) {
            return NodeReference().SetRawJsonValueAsync(ToJson(value));
        }

        public override Task DeleteAsync(CancellationToken cancellationToken = default) {
            return NodeReference().RemoveValueAsync();
        }

        public override async Task<T> ReadAsync(CancellationToken cancellationToken = default) {
            var snapshot = await NodeReference().GetValueAsync();
            return GetValueFromDatabase(snapshot);
        }

        private static T GetValueFromDatabase(DataSnapshot snapshot) {
            var json = snapshot.GetRawJsonValue();
            return string.IsNullOrEmpty(json) ? default : JsonConvert.DeserializeObject<T>(json);
        }

        private DatabaseReference NodeReference() => _reference.Child(_referencePath);
        private static string ToJson(T value) => JsonConvert.SerializeObject(value);
    }
}