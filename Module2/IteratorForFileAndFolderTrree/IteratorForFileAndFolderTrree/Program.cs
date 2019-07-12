using System;
using System.IO;

namespace IteratorForFileAndFolderTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите интересующий вас каталог (пример D:\\\\)\n");
            string startDirectory = Console.ReadLine();
            if (Directory.Exists(startDirectory))
            {
                FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(startDirectory);

                foreach (var item in fileSystemVisitor.CustomIterator())
                {
                    Console.WriteLine(item);
                }

            }
            else
            {
                Console.WriteLine("Такой каталог не существует!");
            }

            Console.WriteLine("Нажмите ENTER для выхода");
            Console.ReadLine();
        }
    }
}
