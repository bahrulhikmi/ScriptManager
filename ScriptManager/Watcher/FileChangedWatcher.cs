using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Watcher
{
    public abstract class FileChangedWatcher
    {
        private FileSystemWatcher watcher;
        public FileChangedWatcher(string path, string filter)
        {
            watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                    | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = filter;

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Error += new ErrorEventHandler(OnError);
        }

        public virtual void Start()
        {
            watcher.EnableRaisingEvents = true;
        }

        public virtual void Stop()
        {
            watcher.EnableRaisingEvents = false;
        }
        public abstract void OnChanged(object source, FileSystemEventArgs e);

        private void OnError(object sender, ErrorEventArgs e)
        {
            PrintException(e.GetException());
        }           

        private void PrintException(Exception ex)
        {
            if (ex != null)
            {
                //TODO Change it to log
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                PrintException(ex.InnerException);
            }
        }
    }
}
