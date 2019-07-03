using System;

namespace ConsoleVariantApplications
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Командная строка содержит " + args.Length + " аргумента.\nВот они: ");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Hello " + args[i]);
            }
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }
    }
}
