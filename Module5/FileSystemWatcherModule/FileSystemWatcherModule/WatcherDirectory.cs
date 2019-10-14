using System;
using System.IO;

namespace FileSystemWatcherModule
{
    class WatcherDirectory
    {
        public void WatcherFile()
        {
            string path = @"D:\TEST\";
            FileSystemWatcher watcher = new FileSystemWatcher();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            watcher.Path = path;

            watcher.NotifyFilter = NotifyFilters.LastAccess
                | NotifyFilters.LastWrite
                | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;
            watcher.Filter = "*.txt";
            watcher.Created += OnChanged;
            watcher.Changed += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnRenamed;

            watcher.EnableRaisingEvents = true;
        }        

        private void OnChanged(object sender, FileSystemEventArgs e) =>
            Console.WriteLine($"File {e.FullPath} has changed - {e.ChangeType}");

        private void OnRenamed(object sender, RenamedEventArgs e) =>
            Console.WriteLine($"File {e.OldName} by path {e.OldFullPath} renamed to {e.Name} by path {e.FullPath}");
    }
}

