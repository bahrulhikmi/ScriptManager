using System.Collections.Generic;

namespace Common.Interfaces
{
   public interface IRunner
    {
        IRunnerResult Run(IDefinitionItem definitionItem, List<IConfigItem> configItems);
    }
}
