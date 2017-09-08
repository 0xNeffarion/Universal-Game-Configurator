using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Universal_Game_Configurator {

    [Serializable]
    [XmlRoot("Descriptions_List")]
    public class Descriptions {

        [XmlArrayItem("Descriptions")]
        public List<Description> descriptions_list { get; set; }

    }
}
