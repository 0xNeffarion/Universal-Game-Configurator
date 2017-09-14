using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Universal_Game_Configurator.Const;
using Universal_Game_Configurator.Objects.Data.Databases;
using Universal_Game_Configurator.Util;

namespace Universal_Game_Configurator.Objects.Data.Helpers {
    public static class DescriptionUtil {

        private static readonly List<Description> descriptions = new List<Description>();

        private static void Deserialize() {
            descriptions.Clear();
            DescriptionsDatabase db = Serialization.Deserialize<DescriptionsDatabase>(Paths.DESCRIPTIONS_PATH);
            descriptions.AddRange(db.Descriptions);
        }

        public static List<Description> Descriptions {
            get {
                if (descriptions.Count <= 0) {
                    Deserialize();
                }
                return descriptions;
            }
        }

        public static Description FromId(int id) {
            return Descriptions.Find(i => i != null && i.Id == id);
        }

    }

}
