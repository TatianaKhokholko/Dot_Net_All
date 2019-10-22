using System;
using System.IO;
using System.Threading;

namespace FileSystemWatcherModule
{
    class Program
    {
        private static readonly AutoResetEvent _closeEvent = new AutoResetEvent(false);
        
        static void Main(string[] args)
        {
            Console.WriteLine("If you want to exit please enter Ctrl+C");
            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                eventArgs.Cancel = true;
                _closeEvent.Set();
            };
            
            WatcherDirectory watcher = new WatcherDirectory();
            watcher.WatcherFile();
            _closeEvent.WaitOne();
        }     
    }
}

