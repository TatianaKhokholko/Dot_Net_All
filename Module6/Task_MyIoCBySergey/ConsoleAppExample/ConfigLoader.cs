using Newtonsoft.Json;

namespace ConsoleAppExample
{
    public class ConfigLoader
    {
        [JsonProperty("Interface")]
        public string Interface { get; set; }

        [JsonProperty("Class")]
        public string Class { get; set; }
    }
}
