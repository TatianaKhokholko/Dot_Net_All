using System;

namespace ConsoleVariantApplications
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Командная строка содержит {args.Length}");

            foreach (string item in args)
            {
                Console.WriteLine($"Hello, {item}");
            }

            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }
    }
}
