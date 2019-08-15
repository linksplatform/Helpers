using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Platform.Helpers.Serialization
{
    public static class Xml
    {
        private static readonly ConcurrentDictionary<Type, XmlSerializer> _xmlSerializerCache = new ConcurrentDictionary<Type, XmlSerializer>();

        public static XmlSerializer GetCachedXmlSerializer<T>() => _xmlSerializerCache.GetOrAdd(typeof(T), type => new XmlSerializer(type));

        public static T FromFile<T>(string path)
        {
            using (var reader = File.OpenRead(path))
            {
                return (T)GetCachedXmlSerializer<T>().Deserialize(reader);
            }
        }

        public static T FromString<T>(string xmlString)
        {
            using (var reader = new StringReader(xmlString))
            {
                return (T)GetCachedXmlSerializer<T>().Deserialize(reader);
            }
        }

        public static void ToFile<T>(T obj, string path)
        {
            using (var fileStream = File.OpenWrite(path))
            {
                GetCachedXmlSerializer<T>().Serialize(fileStream, obj);
            }
        }

        public static string ToString<T>(T obj)
        {
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                GetCachedXmlSerializer<T>().Serialize(writer, obj);
            }
            return sb.ToString();
        }
    }
}
