using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Universal_Game_Configurator {

    [Serializable]
    [XmlRoot("Games_List")]
    public class Games {

        [XmlArrayItem("Games")]
        public List<Game> games_list { get; set; }

    }
}
