using System;

namespace ConsoleAppExample
{
    public class MorningHandler
    {
        private readonly IMorningShitDebug _morningShitDebug;
        private readonly IMorningShitRelease _morningShitRelease;

        public MorningHandler()
        {
            _morningShitDebug = Program.Container.CreateInstance<IMorningShitDebug>();
            _morningShitRelease = Program.Container.CreateInstance<IMorningShitRelease>();
        }

        public void MeetMorning()
        {
            Console.WriteLine("This Morning is");
            _morningShitDebug.GetIt();
            _morningShitRelease.GetIt();
        }
    }
}
