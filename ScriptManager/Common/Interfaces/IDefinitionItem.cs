using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    interface IDefinitionItem
    {
        string Name { get; set; }
        string IconPath { get; set; }
        string Label { get; set; }
        string Category { get; set; }

    }
}
