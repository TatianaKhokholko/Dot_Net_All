using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
namespace ConsoleAppExample
{
    /// <summary>
    /// Kласс для десериализации тестовых данных .json
    /// <summary>
    public class ConfigLoader : IMorningShit
    {
        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        public void GetIt()
        {
            using (StreamReader streamReader = new StreamReader(@"..\..\TestRunConfig\DebugConfig.json"))
            {
                var json = JsonConvert.DeserializeObject<ConfigLoader>(streamReader.ReadToEnd());
                
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(json.Version);
                Console.WriteLine(json.Message);
            }
        }
    }
}
