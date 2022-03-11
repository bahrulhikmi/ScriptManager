using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watcher
{
    public class LogFileWatcher : FileChangedWatcher
    {
        public event EventHandler<LogFileChangedEventArgs> LogFileChanged;
        const string FILE_FILTER = "*.log";
        public LogFileWatcher(string path): base(path, FILE_FILTER)
        {            
        }
        public override void OnChanged(object source, FileSystemEventArgs e)
        {
            LogFileChangedEventArgs eventArgs = new LogFileChangedEventArgs();            
            eventArgs.Message = getLastLine(e.FullPath);
            LogFileChanged(source, eventArgs);
        }


        /// <summary>
        /// Get Last Line of the log file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string getLastLine(string path)
        {
            string lines = string.Empty;

            //Attempt to read the file
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                    using (var sr = new StreamReader(stream))
                    {
                        lines = sr.ReadToEnd();
                        sr.Close();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    //TODO: Change to log
                    Console.WriteLine("Unable to open log file", ex);
                    System.Threading.Thread.Sleep(1000);
                }
            }


            if (!string.IsNullOrWhiteSpace(lines))
            {
                string lastLine = System.Text.RegularExpressions.Regex.Split(lines, "\r\n")?.Last();
                return lastLine;
            }

            return null;
        }
    }


    public class LogFileChangedEventArgs : EventArgs
    {
        public string Message { get; set; }
    }


}
