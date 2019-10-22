using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemWatcherModule
{
    class WatcherDirectory
    {
        protected ModelConfig configs = new ModelConfig();
        protected List<string> directories = new List<string>();
        FileSystemWatcher watcher;

        public void WatcherFile()
        {            
            CreateDirectories();
            foreach (var path in directories)
            {
                watcher = new FileSystemWatcher(path.ToString());
                watcher.NotifyFilter = NotifyFilters.LastAccess
                    | NotifyFilters.LastWrite
                    | NotifyFilters.FileName
                    | NotifyFilters.DirectoryName;                
               
                watcher.Created += OnChanged;
                watcher.Changed += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;
                watcher.EnableRaisingEvents = true;
                CopyToDefaultDirectories(path);
            }
        }

        private void CreateDirectories()
        {
            directories.Add(configs.Directory1());
            directories.Add(configs.Directory2());
            foreach (var directory in directories)
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }
        }

        private void CopyToDefaultDirectories(string directory)
        {
            string[] files = Directory.GetFiles(directory, configs.RuleByNameFile());
            foreach (string file in files)
            {
                File.Copy(Path.Combine(directory, file), Path.Combine(configs.DefaultDirectory(), file), true);
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e) =>
            Console.WriteLine($"File {e.Name} has changed - {e.ChangeType} by path {e.FullPath}");

        private void OnRenamed(object sender, RenamedEventArgs e) =>
            Console.WriteLine($"File {e.OldName} renamed to {e.Name} by path {e.FullPath}");
    }
}

