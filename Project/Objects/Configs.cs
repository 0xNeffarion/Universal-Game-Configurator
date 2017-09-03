using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace Universal_Game_Configurator.Objects {

    [Serializable]
    [XmlRoot("Configs_List")]
    public class Configs {

        [XmlArrayItem("Configs")]
        public List<Description> configs_list { get; set; }

    }
}
