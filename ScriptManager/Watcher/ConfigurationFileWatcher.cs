using System;
using System.IO;

namespace Watcher
{
    class ConfigurationFileWatcher:FileChangedWatcher
    {
        public event EventHandler<ConfigurationFileChangedEventArgs> DefinitionFileChanged;
        const string FILE_FILTER = "configuration.xml";
        public ConfigurationFileWatcher(string path) : base(path, FILE_FILTER)
        {
        }

        public override void OnChanged(object source, FileSystemEventArgs e)
        {
            var changedEvent = new ConfigurationFileChangedEventArgs();
            changedEvent.FullPath = e.FullPath;
            DefinitionFileChanged(source, changedEvent);
        }
    }

    public class ConfigurationFileChangedEventArgs : EventArgs
    {
        public string FullPath { get; set; }
    }
}
