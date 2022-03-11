using System;
using System.IO;

namespace Watcher
{
    public class DefinitionFileWatcher : FileChangedWatcher
    {
        public event EventHandler<DefinitionFileChangedEventArgs> DefinitionFileChanged;
        const string FILE_FILTER = "definition.xml";
        public DefinitionFileWatcher(string path): base(path, FILE_FILTER)
        {

        }
        public override void OnChanged(object source, FileSystemEventArgs e)
        {
            var changedEvent = new DefinitionFileChangedEventArgs();
            changedEvent.FullPath = e.FullPath;
            DefinitionFileChanged(source, changedEvent);
        }
    }

    public class DefinitionFileChangedEventArgs : EventArgs
    {   
        public string FullPath { get; set; }
    }

}
