using System.Collections.Generic;

namespace Common.Interfaces
{
    interface IDefinitionReader
    {
        List<IDefinitionItem> Read();
    }
}
