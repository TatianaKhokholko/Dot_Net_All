using System;

namespace ConsoleAppExample
{
    class MockShitCreator : IMorningShit
    {
        public void GetIt()
        {
            Console.WriteLine("Plastic shit without main functionality");
        }
    }
}
