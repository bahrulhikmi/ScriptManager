using System.Collections.Generic;

namespace Common.Interfaces
{
   public interface IDefinitionReader
    {
        List<IDefinitionItem> Read();
    }
}
