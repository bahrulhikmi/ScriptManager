using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace SwissArmyKnife.Classes
{
    public class ConfigItem : IConfigItem
    {
        public string ConfigKey { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
