using System;
using Autofac;

namespace ConsoleAppExample
{
    class Program
    {
        // start Io Container
        private static readonly string PATH_JSON = @"..\..\TestRunConfig\Release.json";
        private static readonly IContainer Container = IocContainer.Container.Initialize(PATH_JSON);

        static void Main(string[] args)
        {
            MorningHandler morningHandler = new MorningHandler();
            morningHandler.MeetMorning(PATH_JSON);
            Console.ReadKey(); 
        }
    }
}
