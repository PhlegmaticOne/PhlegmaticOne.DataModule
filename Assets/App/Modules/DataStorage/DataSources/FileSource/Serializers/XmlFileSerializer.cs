using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace PhlegmaticOne.DataStorage.DataSources.FileSource.Serializers {
    internal sealed class XmlFileSerializer : IFileSerializer {
        public void Serialize<T>(Stream stream, T value) {
            var serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(stream, value);
        }

        public T Deserialize<T>(Stream stream) {
            var deserializer = new DataContractSerializer(typeof(T));
            return (T)deserializer.ReadObject(stream);
        }

        public string FileExtension => ".xml";
    }
}