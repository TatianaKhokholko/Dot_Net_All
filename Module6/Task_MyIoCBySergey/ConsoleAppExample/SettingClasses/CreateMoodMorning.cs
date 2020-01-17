using System;

namespace ConsoleAppExample.SettingClasses
{
    public class CreateMoodMorning : IMorningShit
    {
        public void GetIt()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Прекрасное утро, что тут скажешь!");
        }
    }
}
