using System.Collections.Generic;

namespace Common.Interfaces
{
    interface IConfigReader
    {
        List<IConfigItem> Read();
    }
}
