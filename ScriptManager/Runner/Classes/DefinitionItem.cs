using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace SwissArmyKnife.Classes
{
    public class DefinitionItem : IDefinitionItem
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public string Label { get; set; }
        public string Category { get; set; }
        public string Path { get; set; }
        public string ScriptFileName { get; set; }
    }
}
