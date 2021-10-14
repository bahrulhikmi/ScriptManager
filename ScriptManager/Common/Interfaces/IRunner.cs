using System.Collections.Generic;

namespace Common.Interfaces
{
    interface IRunner
    {
        IRunnerResult Run(IDefinitionItem definitionItem, List<IConfigItem> configItems);
    }
}
