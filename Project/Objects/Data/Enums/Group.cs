using System.Xml.Serialization;

namespace Universal_Game_Configurator.Objects.Data.Lesser {

    /// <summary>
    /// Config list categories/groups
    /// </summary>
    public enum Group {

        [XmlEnum(Name = "g0")]
        General,

        [XmlEnum(Name = "g1")]
        Graphics,

        [XmlEnum(Name = "g2")]
        Performance,

        [XmlEnum(Name = "g3")]
        Gameplay,

        [XmlEnum(Name = "g4")]
        Other

    }
}
