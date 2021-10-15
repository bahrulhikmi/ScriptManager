namespace Watcher
{
    public class SystemFileWatcherBase
    {
        public override void OnChanged(object source, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}