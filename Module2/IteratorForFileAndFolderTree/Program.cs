using System;
using System.IO;

namespace IteratorForFileAndFolderTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> initializationDirictory = inputUser =>
            {
                string input = "D:\\Study";
                return inputUser.Equals(input);
            };

            Console.WriteLine("Введите интересующий вас каталог\n");
            string startDirectory = Console.ReadLine();
            if (Directory.Exists(startDirectory))
            {
                FilterByDirectoryValue filterByDirectoryValue = new FilterByDirectoryValue();
                if (filterByDirectoryValue.ShowResultAfterFilter(initializationDirictory, startDirectory)==true)
                {
                    FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(startDirectory, initializationDirictory);
                    foreach (var item in fileSystemVisitor.IteratorForDirectories(startDirectory))
                    {
                        Console.WriteLine(item);
                    }
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
