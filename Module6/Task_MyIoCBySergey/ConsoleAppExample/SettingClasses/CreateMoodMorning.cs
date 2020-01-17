using System;

namespace ConsoleAppExample.SettingClasses
{
    public class CreateMoodMorning : IMorningShit
    {
        public void GetIt()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Гумно с дымом!!!");
        }
    }
}
