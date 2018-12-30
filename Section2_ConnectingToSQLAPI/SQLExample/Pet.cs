using Newtonsoft.Json;

namespace SQLExample
{
    public class Pet
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }

        [JsonProperty(PropertyName = "breed")]
        public string Breed { get; set; }
    }
}
