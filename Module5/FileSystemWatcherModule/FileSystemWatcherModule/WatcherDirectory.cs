using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemWatcherModule
{
    class WatcherDirectory
    {
        protected ModelConfig configs = new ModelConfig();

        public void WatcherFile()
        {
            List<string> directories = new List<string>();
            directories.Add(configs.Directory1());
            directories.Add(configs.Directory2());

            foreach (var directory in directories)
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }                               
            }
            //IteratorForWatchingDirectories(directories);
            foreach (var path in directories)
            {
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = path.ToString();

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
                //yield return path;
            }
        }
      
        //public IEnumerable<string> IteratorForWatchingDirectories(List<string> directories)
        //{
        //    foreach (var path in directories)
        //    {
        //        FileSystemWatcher watcher = new FileSystemWatcher();
        //        watcher.Path = path.ToString();

        //        watcher.NotifyFilter = NotifyFilters.LastAccess
        //            | NotifyFilters.LastWrite
        //            | NotifyFilters.FileName
        //            | NotifyFilters.DirectoryName;
        //        watcher.Filter = "*.txt";
        //        watcher.Created += OnChanged;
        //        watcher.Changed += OnChanged;
        //        watcher.Deleted += OnChanged;
        //        watcher.Renamed += OnRenamed;

        //        watcher.EnableRaisingEvents = true;
        //        yield return path;
        //    }
        //}

        private void OnChanged(object sender, FileSystemEventArgs e) =>
            Console.WriteLine($"File {e.FullPath} has changed - {e.ChangeType}");

        private void OnRenamed(object sender, RenamedEventArgs e) =>
            Console.WriteLine($"File {e.OldName} by path {e.OldFullPath} renamed to {e.Name} by path {e.FullPath}");
    }
}

