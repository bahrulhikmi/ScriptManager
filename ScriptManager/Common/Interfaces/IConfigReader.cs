using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IConfigReader
    {
        List<IConfigItem> Read();
    }
}
