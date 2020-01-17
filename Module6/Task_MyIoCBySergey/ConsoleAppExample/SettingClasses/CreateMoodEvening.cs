using System;

namespace ConsoleAppExample.SettingClasses
{
    public class CreateMoodEvening : IEveningShit
    {
        public void GetIt()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Херота! НО ТЕПЕРЬ ПОНИМАЮ!");
        }
    }
}
