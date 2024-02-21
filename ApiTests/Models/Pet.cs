using Newtonsoft.Json;

namespace TestProject.Models
{
    public partial class Pet(long id, string name, string status)
    {
        [JsonProperty("id")]
        public long Id { get; set; } = id;

        [JsonProperty("name")]
        public string Name { get; set; } = name;

        [JsonProperty("photoUrls")]
        public object[]? PhotoUrls { get; set; }

        [JsonProperty("tags")]
        public Tag[]? Tags { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; } = status;
    }

    public partial class Tag
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
