using System;

namespace ConsoleAppExample.SettingClasses
{
    public class CreateMoodEvening : IEveningShit
    {
        public void GetIt()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Вечером чай?!");
        }
    }
}
