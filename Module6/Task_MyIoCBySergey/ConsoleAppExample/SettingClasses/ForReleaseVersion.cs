using System;

namespace ConsoleAppExample.SettingClasses
{
    public class ForReleaseVersion : IMorningShitRelease
    {
        public void GetIt()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Херота! НО ТЕПЕРЬ ПОНИМАЮ!");
        }
    }
}
