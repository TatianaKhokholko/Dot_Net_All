using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppExample.SettingClasses
{
    public class ForReleaseVersion : IMorningShit
    {
        public void GetIt()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Херота - не понимаю!");
        }
    }
}
