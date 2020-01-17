using System;

namespace ConsoleAppExample
{
    public class MorningHandler
    {
        private readonly IMorningShit _morningShit;
        private readonly IEveningShit _eveningShit;

        public MorningHandler()
        {
            _morningShit = Program.Container.CreateInstance<IMorningShit>();
            _eveningShit = Program.Container.CreateInstance<IEveningShit>();
        }

        public void MeetMorning()
        {
            Console.WriteLine("This Morning is");
            _morningShit.GetIt();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("This Evening is");
            _eveningShit.GetIt();
        }
    }
}
