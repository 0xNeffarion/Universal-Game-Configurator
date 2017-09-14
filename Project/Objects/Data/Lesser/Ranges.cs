using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Universal_Game_Configurator.Objects.Data.Helpers {

    [Serializable]
    public class Ranges {

        [XmlIgnore]
        private const Double MIN_DEFAULT = -99999;

        [XmlIgnore]
        private const Double MAX_DEFAULT = 99999;

        [XmlElement("Min")]
        [DefaultValue(MIN_DEFAULT)]
        public Double Minimum = MIN_DEFAULT;

        [XmlElement("Max")]
        [DefaultValue(MAX_DEFAULT)]
        public Double Maximum = MAX_DEFAULT;

        public Boolean HasMinimum() {
            return this.Minimum != MIN_DEFAULT;
        }

        public Boolean HasMaximum() {
            return this.Maximum != MAX_DEFAULT;
        }

    }
}
