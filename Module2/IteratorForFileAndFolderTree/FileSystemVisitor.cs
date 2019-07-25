using System;
using System.Collections.Generic;
using System.IO;

namespace IteratorForFileAndFolderTree
{
    public class FileSystemVisitor
    {
        private readonly Func<string, bool> _filter;
  
        public FileSystemVisitor(Func<string, bool> filter)
        {
            _filter = filter;
        }

        public event Action<string> Start;
        public event Action<string> Finish;
        public event Action<string> DirectoryFinded;
        public event Action<string> FileFinded;
        public event Action<string> FilteredDirectoryFinded;
        public event Action<string> FilteredFileFinded;
   

        protected virtual void OnStart(string path) 
        {
            Start?.Invoke(path);
            Console.WriteLine(path);
        }

        protected virtual void OnFinish(string path)
        {
            Finish?.Invoke(path);
            Console.WriteLine(path);
        }

        protected virtual void OnFileFinded(string path) //запуск события до фильтрации
        {
            FileFinded?.Invoke(path);
            Console.WriteLine(path);
        }

        protected virtual void OnDirectoryFinded(string path) //запуск события до фильтрации
        {
            DirectoryFinded?.Invoke(path);
            Console.WriteLine(path);
        }

        protected virtual void OnFilteredFileFinded(string path) //запуск события после фильтрации
        {
            FilteredFileFinded?.Invoke(path);
            Console.WriteLine(path);
        }

        protected virtual void OnFilteredDirectoryFinded(string path) //запуск события после фильтрации
        {
            FilteredDirectoryFinded?.Invoke(path);
            Console.WriteLine(path);
        }

        public IEnumerable<string> IteratorForDirectories(string startDirectory)
        {
            OnStart("Я начал поиск");
            List<string> result = new List<string>();

            string[] directories = Directory.GetDirectories(startDirectory);
            // отфильтруй мне коллекцию дирректорий и присоедени её к результирующему List
            result.AddRange(FilterForPaths(directories, "Директории:\n"));

            string[] files = Directory.GetFiles(startDirectory);
            // к полученному выше результату присоедени мне отфильтрованную коллекцию файлов
            result.AddRange(FilterForPaths(files, "Файлы:\n"));

            OnFinish("Я закончил поиск");
            return result;
        }

        private IEnumerable<string> FilterForPaths(string[] paths, string prefix)
        {
            foreach (var path in paths)
            {
                //OnDirectoryFinded("Событие для всех найденных папок до фильтрации");
                //OnFileFinded("Событие для всех найденных файлов до фильтрации");
             
                if (_filter(path) & prefix.Contains("Дир"))
                {
                    OnFilteredDirectoryFinded("Я нашел такие директории:\n" + prefix + path);
                    yield return prefix + path;
                }
                else
                {
                    OnFilteredFileFinded("Я нашел такие файлы:\n" + prefix + path);
                    yield return prefix + path;
                }
            }
        }
    }
}
