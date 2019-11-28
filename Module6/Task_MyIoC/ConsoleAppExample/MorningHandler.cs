using System;

namespace ConsoleAppExample
{
    public class MorningHandler
    {
        private readonly IMorningShit _morningShit;// = new ShitCreator();

        //public MorningHandler(IMorningShit morningShit)
        //{
        //    _morningShit = morningShit;
        //}

        public void MeetMorning(int counters)
        {
            Console.WriteLine("Such a beautiful morning!");
            _morningShit.GetIt();
            for (int i = 0; i < counters; i++)
            {
                Console.WriteLine(" Miu ");
            }
            Console.WriteLine("Sad story about cats morning");
        }
    }
}
