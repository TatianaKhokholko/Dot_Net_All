using System;

namespace ConsoleAppExample
{
    public class MorningHandler
    {
        private readonly IMorningShit _morningShit;// = new ShitCreator();

        public MorningHandler(IMorningShit morningShit)
        {
            _morningShit = morningShit;
        }

        public void MeetMorning()
        {
            Console.WriteLine("This Morning is");
            _morningShit.GetIt();
        }
    }
}
