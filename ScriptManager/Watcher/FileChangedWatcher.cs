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

            watcher.Changed += new FileSystemEventHandler(InternalOnChanged);
            watcher.Error += new ErrorEventHandler(InternalOnError);
        }

        public virtual void Start()
        {
            watcher.EnableRaisingEvents = true;
        }

        public virtual void Stop()
        {
            watcher.EnableRaisingEvents = false;
        }


        Dictionary<string, DateTime> lastReads = new Dictionary<string, DateTime>();
        /// <summary>
        /// Handle the on changed internally before raising an event (e.g useful for logging)
        /// </summary>
        private void InternalOnChanged(object source, FileSystemEventArgs e)
        {
            DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
            if (lastReads.ContainsKey(e.FullPath) && lastReads[e.FullPath] == lastWriteTime) return;

            lastReads[e.FullPath] = lastWriteTime;
            OnChanged(source, e);
        }
        public abstract void OnChanged(object source, FileSystemEventArgs e);

        /// <summary>
        /// Handle the on changed internally before raising an event (e.g useful for logging)
        /// </summary>
        private void InternalOnError(object source, ErrorEventArgs e)
        {
            OnError(source, e);
        }

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
