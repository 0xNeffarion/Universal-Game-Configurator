using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Universal_Game_Configurator.Objects.Data;
using Universal_Game_Configurator.Objects.Data.Databases;
using Universal_Game_Configurator.Objects.Data.Lesser;

namespace Universal_Game_Configurator.Util {
    public static class Serialization {

        /// <summary>
        /// All class types that are used to deserialize/serialize
        /// </summary>
        private readonly static Type[] XmlTypes = new Type[] {
                typeof(GamesDatabase),
                typeof(ConfigsDatabase),
                typeof(DescriptionsDatabase),
                typeof(Game),
                typeof(ConfigEntry),
                typeof(ConfigFile),
                typeof(Description),
                typeof(DescriptionValue)
        };

        private static readonly Dictionary<Type, XmlSerializer> XmlSerializerCache = new Dictionary<Type, XmlSerializer>();

        /// <summary>
        /// Fills XmlSerializerCache Dictionary to use as cache
        /// </summary>
        public static void CreateXmlSerializersCache() {
            XmlSerializer[] serializers = XmlSerializer.FromTypes(XmlTypes);
            for (int i = 0; i < serializers.Length; i++) {
                XmlSerializerCache.Add(XmlTypes[i], serializers[i]);
            }
        }

        /// <summary>
        /// Deserializes any cached object using cached XmlSerializers
        /// </summary>
        /// <param name="filePath">XML full file path</param>
        /// <returns>Deserialized object or null if it fails</returns>
        public static T Deserialize<T>(String filePath) {
            XmlSerializer serializer;
            Type type = typeof(T);
            T gen = default(T);

            if (XmlSerializerCache.TryGetValue(type, out serializer)) {
                StreamReader reader = new StreamReader(filePath);
                using (reader) {
                    gen = (T)serializer.Deserialize(reader);
                }
                reader.Close();
            }

            return gen;
        }


    }
}
