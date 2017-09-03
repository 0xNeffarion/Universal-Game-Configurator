using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
namespace Universal_Game_Configurator {

    [Serializable]
    [XmlRoot("Config")]
    public class Config : INotifyPropertyChanged {

        // -------------- NOTIFY CHANGED PRIVATE VALUES

        private String _Value { get; set; }

        // ----------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private void PropertyChangedVal(string prop) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        // ----------------------------------------------------------

        [XmlArrayItem("range")]
        public Decimal[] Range = new Decimal[2];

        [XmlArrayItem("values_desc")]
        public Dictionary<String, String> ValueDesc { get; set; }

        [XmlElement("fixed")]
        public Boolean IsFixedValues { get; set; }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("type")]
        public int Type { get; set; }

        [XmlElement("index")]
        public short FileIndex { get; set; }

        [XmlElement("section")]
        public String Section { get; set; }

        [XmlElement("default")]
        public String Default { get; set; }
        
        public int IsChanged { get; set; }

        [XmlElement("var_name")]
        public String Variable { get; set; }

        [XmlElement("var_value")]
        public String Value {
            get {
                return _Value;
            }
            set {
                _Value = value;
                PropertyChangedVal("Value");
            }
        }

        [XmlElement("desc")]
        public String Description { get; set; }

        [XmlElement("name")]
        public String Name { get; set; }

        [XmlElement("group")]
        public Groups Group { get; set; }

        [XmlElement("interval")]
        public double Interval { get; set; }




    }
}
