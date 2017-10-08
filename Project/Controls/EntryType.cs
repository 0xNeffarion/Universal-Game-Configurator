using System.Xml;
using System.Xml.Serialization;

namespace Universal_Game_Configurator.Controls {

    public enum EntryType {
        [XmlEnum(Name = "e0")]
        IntegerUpDown = 0,

        [XmlEnum(Name = "e1")]
        StringTextBox = 1,

        [XmlEnum(Name = "e2")]
        DoubleUpDown = 2,

        [XmlEnum(Name = "e3")]
        BooleanNormalComboBox = 3,

        [XmlEnum(Name = "e4")]
        BooleanYesNoComboBox = 4,

        [XmlEnum(Name = "e5")]
        BooleanBinaryComboBox = 5,

        [XmlEnum(Name = "e6")]
        DoubleSlider = 6,

        [XmlEnum(Name = "e7")]
        IntegerSlider = 7,

        [XmlEnum(Name = "e8")]
        ComboWithDescriptions = 8
    }



}
