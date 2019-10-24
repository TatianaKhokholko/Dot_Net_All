using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemWatcherModule
{
    class WatcherDirectory
    {
        private ModelConfig _configs = new ModelConfig();
        private List<string> _directories;

        public void WatcherFile()
        {
            CreateDirectories();
            _directories = SetListenedDirectories();
           
            foreach (var path in _directories)
            {
                FileSystemWatcher watcher = new FileSystemWatcher(path.ToString());
                watcher.NotifyFilter = NotifyFilters.LastAccess
                    | NotifyFilters.LastWrite
                    | NotifyFilters.FileName
                    | NotifyFilters.DirectoryName;
                watcher.EnableRaisingEvents = true;

                watcher.Created += OnChanged;
                watcher.Changed += ListenFile;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;            
            }
        }

        private void CreateDirectories()
        {
            var operationDirectories = new List<string>();
            operationDirectories.Add(_configs.Directory1);
            operationDirectories.Add(_configs.Directory2);
            operationDirectories.Add(_configs.DefaultDirectory);

            foreach (var directory in operationDirectories)
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
            result.Add(_configs.Directory1);
            result.Add(_configs.Directory2);
            return result;
        }

        private void CopyToDefaultDirectories(string path)
        {
            string[] filesWithPath = Directory.GetFiles(path, _configs.RuleByNameFile);
            foreach (string fileWithPath in filesWithPath)
            {
                string newFileName = fileWithPath.Replace(path, "");
                string destenationPath = Path.Combine(_configs.DefaultDirectory, newFileName);

                File.Copy(fileWithPath, destenationPath, true);
                Console.WriteLine($"File {newFileName} was copy to {destenationPath}");
            }
        }

        private void ListenFile(object sender, FileSystemEventArgs e)
        {
            foreach (var path in _directories)
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

