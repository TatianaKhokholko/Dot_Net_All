using System;
using System.IO;

namespace IteratorForFileAndFolderTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> initializationDirictory = input =>
            {
                return input.Contains("r");
            };

            Console.WriteLine("Введите интересующий вас каталог\n");
            string startDirectory = Console.ReadLine();

            FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(initializationDirictory);
            //fileSystemVisitor.Start += listeningEvent;
            foreach (var item in fileSystemVisitor.IteratorForDirectories(startDirectory))
            {
                Console.WriteLine(item);
            }
               
            Console.WriteLine("Нажмите ENTER для выхода");
            Console.ReadLine();
        }

        //private static void listeningEvent(string obj)
        //{
        //    Console.WriteLine("");
        //}
    }
}
