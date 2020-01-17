using System;

namespace ConsoleAppExample
{
    public class MorningHandler
    {
        private readonly IMorningShit _morningShitDebug;
        private readonly IEveningShit _morningShitRelease;

        public MorningHandler()
        {
            _morningShitDebug = Program.Container.CreateInstance<IMorningShit>();
            _morningShitRelease = Program.Container.CreateInstance<IEveningShit>();
        }

        public void MeetMorning()
        {
            Console.WriteLine("This Morning is");
            _morningShitDebug.GetIt();
            _morningShitRelease.GetIt();
        }
    }
}
