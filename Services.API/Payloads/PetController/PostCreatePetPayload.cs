using Core.Utils;
using Services.API.Models.PetController.Request;
using Services.API.Models.PetController.Shared;

namespace Services.API.Payloads.PetController
{
    public static class PostCreatePetPayload
    {
        public static PostCreatePetRequestModel Set()
        {
            var model = new PostCreatePetRequestModel
            {
                Id = DataGenerator.NumericInfo.GenerateRandomInteger(9999),
                Name = DataGenerator.PersonalInfo.GenerateFirstName(),
                Status = DataGenerator.TextInfo.GenerateWord(),
                Category = new Category
                {
                    Id = DataGenerator.NumericInfo.GenerateRandomInteger(10),
                    Name = DataGenerator.TextInfo.GenerateSentence(),
                },
                PhotoUrls = new List<string> 
                { 
                    $"https//example.com/photo{DataGenerator.NumericInfo.GenerateRandomInteger(9999)}",
                    $"https//example.com/photo{DataGenerator.NumericInfo.GenerateRandomInteger(9999)}"
                },
                Tags = new List<Tag>
                {
                    new() { Id = DataGenerator.NumericInfo.GenerateRandomInteger(10), Name = DataGenerator.AddressInfo.GenerateCity() },
                    new() { Id = DataGenerator.NumericInfo.GenerateRandomInteger(10), Name = DataGenerator.TextInfo.GenerateWord() }
                }
            };

            return model;
        }
    }
}
