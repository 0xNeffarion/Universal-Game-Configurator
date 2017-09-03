using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Universal_Game_Configurator.Objects {

    [Serializable]
    [XmlRoot("Descriptions_List")]
    public class Descriptions {

        [XmlArrayItem("Descriptions")]
        public List<Description> descriptions_list { get; set; }

    }
}
