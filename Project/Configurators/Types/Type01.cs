using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Universal_Game_Configurator.Configurators.Types {
    /// <summary>
    /// SPACE ENGINEERS CONFIG 
    /// 
    /// XML BASED
    /// </summary>
    public class Type01 : Configurator {
        public List<string> Files { get; set; }

        public void WriteValue(Config cf) {
            XDocument doc = XDocument.Load(Files[cf.FileIndex]);
            var result = doc.Descendants("dictionary");
            var items = result.Descendants("item");
            foreach (var item in items) {
                var xElement = item.Element("Key");
                if (xElement != null && xElement.Value == cf.Variable) {
                    // Edit
                    var element = item.Element("Value");
                    element?.SetValue(cf.Value);
                    doc.Save(Files[cf.FileIndex]);
                    return;
                }
            }

            // Create
            XElement ItemRoot = new XElement("item");
            XElement key = new XElement("Key");
            key.Add(new XAttribute("xsi:type", "xsd:string"));
            key.SetValue(cf.Variable);
            XElement val = new XElement("Value");
            val.Add(new XAttribute("xsi:type", "xsd:string"));
            val.SetValue(cf.Value);
            ItemRoot.Add(key);
            ItemRoot.Add(val);
            doc?.Element("Dictionary")?.Element("dictionary")?.Add(ItemRoot);
            doc.Save(Files[cf.FileIndex]);

        }

        public string ReadValue(string variable, string section = "", short index = 0) {
            try {
                XDocument doc = XDocument.Load(Files[index]);
                var result = doc.Descendants("dictionary");
                var items = result.Descendants("item");
                foreach (var item in items) {
                    var xElement = item.Element("Key");
                    if (xElement != null && xElement.Value == variable) {
                        var element = item.Element("Value");
                        if (element != null) return element.Value;
                    }
                }
            } catch (Exception e) { }

            return null;
        }

        public string ReadValue(Config cg) {
            throw new NotImplementedException();
        }
    }
}
