using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watcher
{
    public class SystemFileWatcher : FileChangedWatcher
    {
        const string FILE_FILTER = "";
        public SystemFileWatcher(string path): base(path, FILE_FILTER)
        {

        }
        public override void OnChanged(object source, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
