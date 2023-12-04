using System.Text;
using Newtonsoft.Json;

namespace App.Scripts.Common.Extensions
{
    public static class ObjectExtensions
    {
        private static readonly JsonSerializerSettings Settings = new()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        
        public static byte[] SerializeToJsonBytes<T>(this T value, string prefix = null)
        {
            var json = JsonConvert.SerializeObject(value, Settings);
            var resultString = string.IsNullOrEmpty(prefix) ? json : prefix + json;
            var bytes = Encoding.UTF8.GetBytes(resultString);
            return bytes;
        }
    }
}