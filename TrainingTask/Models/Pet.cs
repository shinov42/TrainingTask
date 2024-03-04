using Newtonsoft.Json;

namespace TrainingTask.Models
{
    public partial class Pet
    {
        public Pet(long id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photoUrls")]
        public object[]? PhotoUrls { get; set; }

        [JsonProperty("tags")]
        public Tag[]? Tags { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class Tag
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
