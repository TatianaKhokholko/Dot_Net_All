using System;

namespace ConsoleAppExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // start Io Container
#if (DEBUG)
            Console.WriteLine("Debug version.");
            MorningHandler morningHandler = new MorningHandler(new MockShitCreator());
            morningHandler.MeetMorning();
#elif (RELEASE)
            Console.WriteLine("Release version.");
            MorningHandler morningHandler = new MorningHandler(new ShitCreator());
            morningHandler.MeetMorning();
#endif
            Console.ReadKey();
        }
    }
}
