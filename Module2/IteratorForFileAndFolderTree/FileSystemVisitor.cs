using System;
using System.Collections.Generic;
using System.IO;

namespace IteratorForFileAndFolderTree
{
    public class FileSystemVisitor
    {
        private readonly string startDirectory;
        private readonly Func<string, bool> filterForDirictory;

        public FileSystemVisitor(string startDirectory, Func<string, bool> filterForDirictory = null)
        {
            this.startDirectory = startDirectory;
            this.filterForDirictory = filterForDirictory;
        }

        public IEnumerable<string> IteratorForDirectories(string startDirectory)
        {
            string[] directories = Directory.GetDirectories(startDirectory);
            foreach (string dir in directories)
            {
                yield return "\nКаталог: " + dir;

                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    yield return "---Файлы:---";
                    yield return file;
                }

                string[] subDirectories = Directory.GetDirectories(dir);
                foreach (string subDir in subDirectories)
                {
                    yield return "\nПодкаталог: " + subDir;
                    string[] filesSubDirectory = Directory.GetFiles(subDir);
                    foreach (string file in filesSubDirectory)
                    {
                        yield return "---Файлы:---";
                        yield return file;
                    }
                }
            }
        }

    }
}
