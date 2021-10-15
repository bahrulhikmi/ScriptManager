using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Reader
{
    public class DefinitionReader : IDefinitionReader
    {
        public List<IDefinitionItem> Read()
        {
            var files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Said-Plugins", "definition.xml", SearchOption.AllDirectories);
            var items = new List<IDefinitionItem>();
            foreach (var file in files)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.ChildNodes;
                var item = new DefinitionItem();
                item.Path = Path.GetDirectoryName(file);
                foreach (XmlNode node in nodes)
                {
                    item[node.Name] = node.InnerText;
                }
                items.Add(item);
            }
            return items;
        }
    }
}
