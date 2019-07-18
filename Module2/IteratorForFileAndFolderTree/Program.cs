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
            FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(startDirectory, initializationDirictory);

            FilterByDirectoryValue filterByDirectoryValue = new FilterByDirectoryValue();
            if (filterByDirectoryValue.ShowResultAfterFilter(initializationDirictory, startDirectory) != false)
            {
                foreach (var item in fileSystemVisitor.IteratorForDirectories(startDirectory))
                {
                    Console.WriteLine(item);
                }
               
            }
            Console.WriteLine("Нажмите ENTER для выхода");
            Console.ReadLine();
        }
    }
}
