using Newtonsoft.Json;

namespace PhlegmaticOne.DataStorage.DataSources.PlayerPrefsSource.Converters {
    internal sealed class JsonEntityConverter : IEntityConverter {
        public string Convert<T>(T value) {
            return JsonConvert.SerializeObject(value);
        }

        public T ConvertBack<T>(string value) {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}