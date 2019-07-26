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
            OnStart("Я начал поиск\n");
            List<string> result = new List<string>();

            string[] directories = Directory.GetDirectories(startDirectory);
            // отфильтруй мне коллекцию дирректорий и присоедени её к результирующему List
            result.AddRange(FilterForPaths(directories, "Директория: "));

            string[] files = Directory.GetFiles(startDirectory);
            // к полученному выше результату присоедени мне отфильтрованную коллекцию файлов
            result.AddRange(FilterForPaths(files, "Файл: "));

            OnFinish("\nЯ закончил поиск\nПолный список объектов, выбранного пути:");
            return result;
        }

        private IEnumerable<string> FilterForPaths(string[] paths, string prefix)
        {
            foreach (var path in paths)
            {
                if (prefix.Contains("Дир"))
                {
                    OnDirectoryFinded("Найденные папки до фильтрации: " + prefix + path);
                }
                else
                {
                    OnFileFinded("Найденные файлы до фильтрации: " + prefix + path);
                }

                yield return prefix + path;
            }

            foreach (var path in paths)
            {
                if (_filter(path))
                {
                    if (prefix.Contains("Дир"))
                    {
                        OnFilteredDirectoryFinded("Найденные папки после фильтрации: " + prefix + path);
                    }
                    else
                    {
                        OnFilteredFileFinded("Найденные файлы после фильтрации " + prefix + path);
                    }             
                }
                yield return prefix + path;
            }
        }
    }
}
