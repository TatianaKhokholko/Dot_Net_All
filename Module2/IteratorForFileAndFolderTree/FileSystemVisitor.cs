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

        public IEnumerable<string> IteratorForDirectories(string startDirectory)
        {
            List<string> result = new List<string>();

            string[] directories = Directory.GetDirectories(startDirectory);
            // отфильтруй мне коллекцию дирректорий и присоедени её к результирующему List
            result.AddRange(FilterForPaths(directories, "Директория:\n"));

            string[] files = Directory.GetFiles(startDirectory);
            // к полученному выше результату присоедени мне отфильтрованную коллекцию файлов
            result.AddRange(FilterForPaths(files, "Файл:\n"));

            return result;
        }

        private IEnumerable<string> FilterForPaths(string[] paths, string prefix)
        {
            foreach (var path in paths)
            {
                if (_filter(path))
                {
                    yield return prefix + path;
                }
            }
        }
    }
}
