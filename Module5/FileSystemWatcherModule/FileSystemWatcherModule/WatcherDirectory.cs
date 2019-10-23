using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemWatcherModule
{
    class WatcherDirectory
    {
        private ModelConfig configs = new ModelConfig();
        private List<string> directories;

        public void WatcherFile()
        {
            CreateDirectories();
            directories = SetListenedDirectories();
           
            foreach (var path in directories)
            {
                FileSystemWatcher watcher = new FileSystemWatcher(path.ToString());
                watcher.NotifyFilter = NotifyFilters.LastAccess
                    | NotifyFilters.LastWrite
                    | NotifyFilters.FileName
                    | NotifyFilters.DirectoryName;
                watcher.EnableRaisingEvents = true;

                watcher.Created += OnChanged;
                watcher.Changed +=  OnCopeFileInDefaultDirectory;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;            
            }
        }

        private void CreateDirectories()
        {
            var result = new List<string>();
            result.Add(configs.Directory1);
            result.Add(configs.Directory2);
            result.Add(configs.DefaultDirectory);
            foreach (var directory in result)
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }
        }

        private List<string> SetListenedDirectories()
        {
            var result = new List<string>();
            result.Add(configs.Directory1);
            result.Add(configs.Directory2);
            return result;
        }

        private void CopyToDefaultDirectories(string path)
        {
            string[] filesWithPath = Directory.GetFiles(path, configs.RuleByNameFile);
            foreach (string fileWithPath in filesWithPath)
            {
                string newFileName = fileWithPath.Replace(path, "");
                string destenationPath = Path.Combine(configs.DefaultDirectory, newFileName);

                File.Copy(fileWithPath, destenationPath, true);
                Console.WriteLine($"File {newFileName} was copy to {destenationPath}");
            }
        }

        private void OnCopeFileInDefaultDirectory(object sender, FileSystemEventArgs e)
        {          
            directories = SetListenedDirectories();
            foreach (var path in directories)
            {
                CopyToDefaultDirectories(path);               
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e) =>
            Console.WriteLine($"File {e.Name} has changed - {e.ChangeType} by path {e.FullPath}");

        private void OnRenamed(object sender, RenamedEventArgs e) =>
            Console.WriteLine($"File {e.OldName} renamed to {e.Name} by path {e.FullPath}");
    }
}

