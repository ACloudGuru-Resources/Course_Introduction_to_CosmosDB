using System.Collections.Generic;
using Newtonsoft.Json;

namespace SQLExample
{
    public class Owner
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "ownerName")]
        public string OwnerName { get; set; }

        [JsonProperty(PropertyName = "telephone")]
        public string Telephone { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "registration")]
        public Registration Registration { get; set; }

        [JsonProperty(PropertyName = "pets")]
        public List<Pet> Pets { get; set; }
    }
}
