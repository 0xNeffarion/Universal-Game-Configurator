using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Universal_Game_Configurator {

    /// <summary>
    /// Game configuration entry. 
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    [Serializable]
    [XmlRoot("ConfigEntry")]
    public class ConfigEntry : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        // ----------------------------------------------------------
        
        /// <summary>
        /// Entry value minimum and maximum range (If any)
        /// </summary>
        [XmlArrayItem("range")]
        public Decimal[] Range = new Decimal[2];

        /// <summary>
        /// Map used to translate config values.
        /// Example (Game difficulty): 
        ///          0 equals Easy
        ///          1 equals Normal
        ///          2 equals Hard
        /// </summary>
        [XmlArrayItem("values_desc")]
        public Dictionary<String, String> ValueDesc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("fixed")]
        public Boolean IsFixedValues { get; set; }

        /// <summary>
        /// Unique ID of entry
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Entry Type enum
        /// </summary>
        [XmlElement("type")]
        public EntryType Type { get; set; }

        /// <summary>
        /// Index for the config file list
        /// </summary>
        [XmlElement("index")]
        public short FileIndex { get; set; }

        /// <summary>
        /// Variable section in config file (if it exists)
        /// </summary>
        [XmlElement("section")]
        public String Section { get; set; }

        /// <summary>
        /// Default value for the variable (if it exists)
        /// </summary>
        [XmlElement("default")]
        public Object Default { get; set; }
        
        /// <summary>
        /// Flag for changed setting in settings list
        /// </summary>
        public Boolean IsChanged { get; set; }

        /// <summary>
        /// Variable name in the config file
        /// </summary>
        [XmlElement("var_name")]
        public String Variable { get; set; }

        /// <summary>
        /// Variable value in the config file
        /// </summary>
        [XmlElement("var_value")]
        public String Value { get; set; }

        /// <summary>
        /// Variable description
        /// </summary>
        [XmlElement("desc")]
        public String Description { get; set; }

        /// <summary>
        /// Variable title/name
        /// </summary>
        [XmlElement("name")]
        public String Name { get; set; }

        /// <summary>
        /// Variable group for the settings list. Groups Enum
        /// </summary>
        [XmlElement("group")]
        public Groups Group { get; set; }

        /// <summary>
        /// Variable value interval. For Sliders and UpDown UI Boxes
        /// </summary>
        [XmlElement("interval")]
        public Double Interval { get; set; }

    }
}
