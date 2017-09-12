using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Universal_Game_Configurator.Const;
using Universal_Game_Configurator.Objects.Data.Databases;

namespace Universal_Game_Configurator.Objects.Data.Helpers {
    public static class DescriptionUtil {

        private static readonly List<Description> descriptions = new List<Description>();

        private static void deserialize() {
            XmlSerializer serializer = new XmlSerializer(typeof(DescriptionsDatabase));
            StreamReader reader = new StreamReader(Paths.DESCRIPTIONS_PATH);
            DescriptionsDatabase descs = null;
            descs = (DescriptionsDatabase)serializer.Deserialize(reader);

            descriptions.AddRange(descs.Descriptions);
        }

        public static List<Description> Descriptions {
            get {
                if (descriptions.Count <= 0) {
                    deserialize();
                }
                return descriptions;
            }
        }

        public static Description FromId(int id) {
            return Descriptions.Find(i => i != null && i.Id == id);
        }

    }

}
