using System;

namespace ConsoleAppExample.SettingClasses
{
    public class ForDebugVersion : IMorningShitDebug
    {
        public void GetIt()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Говно с дымом!");
        }
    }
}
