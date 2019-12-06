using System;
using ConsoleAppExample.IocContainer;

namespace ConsoleAppExample
{
    class Program
    {
        // start Io Container
        public static Container Container = new Container();

        static void Main(string[] args)
        {
            Container.RegistreDependency(typeof(IMorningShit), typeof(ShitCreator));

            Console.WriteLine("Debug version.");
            MorningHandler morningHandler = new MorningHandler();
            morningHandler.MeetMorning();
            Console.ReadKey();
        }
    }
}
