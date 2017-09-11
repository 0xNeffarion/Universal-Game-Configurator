using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Universal_Game_Configurator {
    public static class DescriptionUtil {

        private static readonly List<Description> descriptions = new List<Description>();

        private static void deserialize() {
            XmlSerializer serializer = new XmlSerializer(typeof(Descriptions));
            StreamReader reader = new StreamReader(Paths.DESCRIPTIONS_PATH);
            Descriptions descs = null;
            descs = (Descriptions)serializer.Deserialize(reader);

            descriptions.AddRange(descs.DescriptionsList);
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
