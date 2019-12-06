using System;

namespace ConsoleAppExample
{
    public class MorningHandler
    {
        private readonly IMorningShit _morningShit;// = new ShitCreator();

        public MorningHandler()
        {
            _morningShit = Program.Container.CreateInstance<IMorningShit>();
        }

        public void MeetMorning()
        {
            Console.WriteLine("This Morning is");
            _morningShit.GetIt();
        }
    }
}
