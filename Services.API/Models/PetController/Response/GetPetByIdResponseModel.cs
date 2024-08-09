using Services.API.Models.PetController.Shared;
using System.Text.Json.Serialization;

namespace Services.API.Models.PetController.Response
{
    public class GetPetByIdResponseModel
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("category")]
        public Category? Category { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("photoUrls")]
        public List<object>? PhotoUrls { get; set; }

        [JsonPropertyName("tags")]
        public List<object>? Tags { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }
    }
}
