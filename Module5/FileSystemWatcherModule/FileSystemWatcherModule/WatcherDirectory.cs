using System;
using System.IO;

namespace FileSystemWatcherModule
{
    class WatcherDirectory
    {
        public void WatcherFile()
        {
            string path = @"D:\TEST\";
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                watcher.Path = path;
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;
                watcher.Filter = "*.txt";
                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;
            }
        }

        private static void OnChanged(object sender, FileSystemEventArgs e) =>
            Console.WriteLine($"File {e.FullPath} has some changed {e.ChangeType}");

        private static void OnRenamed(object sender, RenamedEventArgs e) =>
            Console.WriteLine($"File {e.OldName} {e.OldFullPath} renamed to {e.Name} {e.FullPath}");
    }
}

