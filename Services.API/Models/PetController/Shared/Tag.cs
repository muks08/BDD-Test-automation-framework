using System.Text.Json.Serialization;

namespace Services.API.Models.PetController.Shared
{
    public class Tag
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
