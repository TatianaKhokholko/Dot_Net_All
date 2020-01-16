using System;
using ConsoleAppExample.IocContainer;

namespace ConsoleAppExample
{
    class Program
    {
        public static readonly string PATH_JSON = @"..\..\TestRunConfig\Release.json";

        // start Io Container
        public static Container Container;
        
        static void Main(string[] args)
        {
            Container = new Container(PATH_JSON);

            MorningHandler morningHandler = new MorningHandler();
            morningHandler.MeetMorning();
            Console.ReadKey();
        }
    }
}
