using System;
using System.Collections.Generic;
using System.IO;


namespace IteratorForFileAndFolderTrree
{
    public class FileSystemVisitor
    {
        private readonly string startDirectory;

        public FileSystemVisitor(string startDirectory)
        {
            this.startDirectory = startDirectory;
        }

        public IEnumerable<string> CustomIterator()
        {
            yield return "Каталоги: \n";

            string[] directories = Directory.GetDirectories(startDirectory);
            foreach (string dir in directories)
            {
                yield return dir;
            }

            yield return "Файлы: \n";

            string[] files = Directory.GetFiles(startDirectory);
            foreach (string file in files)
            {
                yield return file;
            }
        }
    }
}
