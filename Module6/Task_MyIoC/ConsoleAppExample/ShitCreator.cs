using System;

namespace ConsoleAppExample
{
    class ShitCreator : IMorningShit
    {
        public void GetIt()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Shit revial!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
