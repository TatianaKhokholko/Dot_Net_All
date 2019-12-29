using System;

namespace ConsoleAppExample.SettingClasses
{
    public class ForDebugVersion : IMorningShit
    {
        public void GetIt()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Говно с дымом!");
        }
    }
}
