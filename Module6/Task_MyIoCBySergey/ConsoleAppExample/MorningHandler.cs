using ConsoleAppExample.Services;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ConsoleAppExample
{
    public class MorningHandler : IMorningShit
    {
        [JsonProperty("version")]
        private string Version { get; set; }

        [JsonProperty("message")]
        private string Message { get; set; }

        public void MeetMorning(string path)
        {
            CreateMorning(path);
        }

        public void CreateMorning(string path)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    var json = JsonConvert.DeserializeObject<MorningHandler>(streamReader.ReadToEnd());
                    Console.WriteLine("Today morning is");
                    Console.WriteLine(json.Message);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"Version program is: {json.Version}");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File was not found {e.Message}");
            }
        }
    }
}
