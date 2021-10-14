using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using Common.Interfaces;

namespace Reader
{
    public class ConfigReader : IConfigReader
    {
        public List<IConfigItem> Read()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+ "\\System\\config.xml");
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.ChildNodes;
            var items = new List<IConfigItem>();
            foreach(XmlNode node in nodes)
            {
                items.Add(new ConfigItem
                {
                    ConfigKey = node.Name,
                    Value = node.InnerText,
                    Type = "String"
                });
            }
            return items;
        }
    }
}
