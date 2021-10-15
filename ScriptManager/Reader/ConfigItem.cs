using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class ConfigItem : IConfigItem
    {
        private string _configKey;
        private string _value;
        private string _type;
        public string ConfigKey { get => _configKey; set => _configKey = value; }
        public string Value { get => _value; set => _value = value; }
        public string Type { get => _type; set => _type = value; }
    }
}
