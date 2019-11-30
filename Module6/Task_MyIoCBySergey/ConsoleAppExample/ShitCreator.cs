using System;

namespace ConsoleAppExample
{
    class ShitCreator : IMorningShit
    {
        public void GetIt()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("AWFUL!!!");
        }
    }
}
