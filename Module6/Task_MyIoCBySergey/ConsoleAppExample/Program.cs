using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleAppExample.IocContainer;

namespace ConsoleAppExample
{
    class Program
    {
        // start Io Container
        //public static Container Container = new Container();
        public static Container Container;
        
        static void Main(string[] args)
        {
            //Container.RegistreDependency(typeof(IMorningShit), typeof(ShitCreator));
            Container = new Container(typeof(IMorningShit), typeof(ConfigLoader));

            MorningHandler morningHandler = new MorningHandler();
            morningHandler.MeetMorning();
            Console.ReadKey();
        }
    }
}
