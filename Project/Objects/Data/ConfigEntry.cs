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
    [Serializable]
    [XmlRoot("ConfigEntry")]
    public class ConfigEntry {

        /// <summary>
        /// Entry value minimum and maximum range (If any)
        /// </summary>
        [XmlArrayItem("range")]
        public Decimal[] Range = new Decimal[2];

        public ConfigEntry(decimal[] range, Dictionary<string, string> valueDesc, bool isFixedValues, int id, EntryType type, int fileIndex,
            string section, object @default, string variable, string value, int description, string name, Group group, double interval) {
            Initialize(range, valueDesc, isFixedValues, id, type, fileIndex, section, @default, variable, value, description, name, group, interval);
        }

        public ConfigEntry(ConfigEntryViewModel vm) {
            Initialize(null, null, false, vm.Id, EntryType.IntegerUpDown, vm.FileIndex, vm.Section, null, vm.Variable, vm.Value, 0, vm.Name, vm.Group, 0);
        }

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
        /// Entry is considered value-fixed if value descriptions are used
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
        public int FileIndex { get; set; }

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
        /// Variable description id
        /// </summary>
        [XmlElement("desc")]
        public int Description { get; set; }

        /// <summary>
        /// Variable title/name
        /// </summary>
        [XmlElement("name")]
        public String Name { get; set; }

        /// <summary>
        /// Variable group for the settings list. Groups Enum
        /// </summary>
        [XmlElement("group")]
        public Group Group { get; set; }

        /// <summary>
        /// Variable value interval. For Sliders and UpDown UI Boxes
        /// </summary>
        [XmlElement("interval")]
        public Double Interval { get; set; }

        public void Initialize(decimal[] range, Dictionary<string, string> valueDesc, bool isFixedValues, int id,
                               EntryType type, int fileIndex, string section, object @default, string variable, string value,
                               int description, string name, Group group, double interval) {
            this.Range = range;
            this.ValueDesc = valueDesc;
            this.IsFixedValues = isFixedValues;
            this.Id = id;
            this.Type = type;
            this.FileIndex = fileIndex;
            this.Section = section;
            this.Default = @default;
            this.Variable = variable;
            this.Value = value;
            this.Description = description;
            this.Name = name;
            this.Group = group;
            this.Interval = interval;
        }

    }
}
