using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Universal_Game_Configurator {

    [Serializable]
    [XmlRoot("Configs_List")]
    public class Config {

        [XmlArrayItem("Configs")]
        public List<Description> configs_list { get; set; }

    }
}
