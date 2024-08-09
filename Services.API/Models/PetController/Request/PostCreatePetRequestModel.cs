using Services.API.Models.PetController.Shared;
using System.Text.Json.Serialization;

namespace Services.API.Models.PetController.Request
{
    public class PostCreatePetRequestModel
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("category")]
        public Category? Category { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("photoUrls")]
        public List<string>? PhotoUrls { get; set; }

        [JsonPropertyName("tags")]
        public List<Tag>? Tags { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }
    }
}
