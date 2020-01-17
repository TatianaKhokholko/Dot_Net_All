using System;

namespace ConsoleAppExample.SettingClasses
{
    public class CreateMoodEveningByMonday : IEveningShit
    {
        public void GetIt()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("А завтра опять на работу =(");
        }
    }
}
