using System;

namespace ConsoleAppExample.SettingClasses
{
    public class CreateMoodMorningByMonday : IMorningShit
    {
        public void GetIt()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Гумно с дымом!!!");
        }
    }
}
