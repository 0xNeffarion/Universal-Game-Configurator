using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using Universal_Game_Configurator.Controls;
using Universal_Game_Configurator.Objects.Data.Helpers;
using Universal_Game_Configurator.Objects.Data.Lesser;

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
        [XmlElement("Ranges")]
        public Ranges Ranges { get; set; }

        /// <summary>
        /// Map used to translate config values.
        /// Example (Game difficulty): 
        ///          0 equals Easy
        ///          1 equals Normal
        ///          2 equals Hard
        /// </summary>
        [XmlArray("DescriptionValues")]
        [XmlArrayItem("Entry")]
        public DescriptionValue[] DescriptionValues { get; set; }

        /// <summary>
        /// Entry is considered value-fixed if descriptions values are used
        /// </summary>
        [XmlIgnore]
        public Boolean IsFixedValues { get { return (DescriptionValues != null && DescriptionValues.Length > 0); } }

        /// <summary>
        /// Unique ID of entry
        /// </summary>
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// Entry Type enum
        /// </summary>
        [XmlElement("Type")]
        public EntryType Type { get; set; }

        /// <summary>
        /// Index for the config file list (starts at 0)
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
        public String Default { get; set; }

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
        public int DescriptionId { get; set; }

        /// <summary>
        /// Description object searched by the description id
        /// </summary>
        [XmlIgnore]
        public Description Description { get { return DescriptionUtil.FromId(this.DescriptionId); } }

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
        [XmlElement("Interval")]
        [DefaultValue(-1)]
        public Double Interval { get; set; }


    }
}
