using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
namespace ConsoleAppExample
{
    /// <summary>
    /// Kласс для чтения и десериализации тестовых данных .json
    /// <summary>
    public class ConfigLoader : IMorningShit
    {
        private readonly string PATH_JSON = @"..\..\TestRunConfig\Debug.json";

        [JsonProperty("Version")]
        private string Version { get; set; }

        [JsonProperty("Message")]
        private string Message { get; set; }

        public void GetIt()
        {
            using (StreamReader streamReader = new StreamReader(PATH_JSON))
            {
                var json = JsonConvert.DeserializeObject<ConfigLoader>(streamReader.ReadToEnd());

                Console.WriteLine($"Version for programm is {json.Version}!");

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(json.Message);
            }
        }
    }
}
