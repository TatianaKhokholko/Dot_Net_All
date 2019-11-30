using System;

namespace ConsoleAppExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // start Io Container
            MorningHandler morningHandler = new MorningHandler();
            morningHandler.MeetMorning(25);
            Console.ReadKey();
        }
    }
}
