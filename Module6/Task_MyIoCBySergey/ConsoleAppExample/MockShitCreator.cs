using System;

namespace ConsoleAppExample
{
    class MockShitCreator : IMorningShit
    {
        public void GetIt()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("BEAUTIFUL!!!");
        }
    }
}
