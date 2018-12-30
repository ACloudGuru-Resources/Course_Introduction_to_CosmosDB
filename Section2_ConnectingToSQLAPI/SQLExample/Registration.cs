
using Newtonsoft.Json;

namespace SQLExample
{
    public class Registration
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "cost")]
        public decimal Cost { get; set; }
    }
}
