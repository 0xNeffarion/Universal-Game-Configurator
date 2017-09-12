using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Universal_Game_Configurator.Controls;

namespace Universal_Game_Configurator.Objects.Data {

    /// <summary>
    /// Game configuration entry. 
    /// </summary>
    [Serializable]
    [XmlRoot("Entry")]
    public class ConfigEntry {

        /// <summary>
        /// Entry value minimum and maximum range (If any)
        /// </summary>
        [XmlArrayItem("Range")]
        public Decimal[] Ranges = new Decimal[2];

        /// <summary>
        /// Map used to translate config values.
        /// Example (Game difficulty): 
        ///          0 equals Easy
        ///          1 equals Normal
        ///          2 equals Hard
        /// </summary>
        [XmlElement("DescriptionValues")]
        public Dictionary<String, String> DescriptionValues { get; set; }

        /// <summary>
        /// Entry is considered value-fixed if value descriptions are used
        /// </summary>
        [XmlElement("IsFixed")]
        public Boolean IsFixedValues { get; set; }

        /// <summary>
        /// Unique ID of entry
        /// </summary>
        [XmlElement("UID")]
        public int Id { get; set; }

        /// <summary>
        /// Entry Type enum
        /// </summary>
        [XmlElement("Type")]
        public EntryType Type { get; set; }

        /// <summary>
        /// Index for the config file list
        /// </summary>
        [XmlElement("FileIndex")]
        public int FileIndex { get; set; }

        /// <summary>
        /// Variable section in config file (if it exists)
        /// </summary>
        [XmlElement("Section")]
        public String Section { get; set; }

        /// <summary>
        /// Default value for the variable (if it exists)
        /// </summary>
        [XmlElement("Default")]
        public Object Default { get; set; }

        /// <summary>
        /// Variable name in the config file
        /// </summary>
        [XmlElement("VariableName")]
        public String Variable { get; set; }

        /// <summary>
        /// Variable value in the config file
        /// </summary>
        [XmlIgnore]
        public String Value { get; set; }

        /// <summary>
        /// Variable description id
        /// </summary>
        [XmlElement("DescriptionId")]
        public int Description { get; set; }

        /// <summary>
        /// Variable title/name
        /// </summary>
        [XmlElement("Name")]
        public String Name { get; set; }

        /// <summary>
        /// Variable group for the settings list. Groups Enum
        /// </summary>
        [XmlElement("Group")]
        public Group Group { get; set; }

        /// <summary>
        /// Variable value interval. For Sliders and UpDown UI Boxes
        /// </summary>
        [XmlElement("ValueInterval")]
        public Double Interval { get; set; }


    }
}
