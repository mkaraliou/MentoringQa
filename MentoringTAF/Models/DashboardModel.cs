using Newtonsoft.Json;

namespace Models
{
    public class DashboardModel
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("share")]
        public bool Share { get; set; }

        public string Owner { get; set; }
    }
}