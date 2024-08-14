using NUnit.Framework;
using RestSharp;
using Services.API;
using Services.API.Models.PetController.Response;
using Services.API.Payloads.PetController;
using System.Net;

namespace Tests.API.Controllers
{
    [TestOf("Swagger URL: https://petstore.swagger.io")]
    public class PetControllerTests : TestBase
    {
        public PetControllerTests() { }

        [Test]
        [Category("Smoke")]
        [Description("Verifies that POST create a pet to (v2/pet/) returns 200, indicating a successful operation")]
        public async Task VerifyPostCreatePetReturns200()
        {
            // Arrange
            var request = RequestFactory.Create(Method.Post, Paths.PetController).AddJsonBody(PostCreatePetPayload.Set());

            // Act
            var response = await ApiService.ExecuteAsync<GetRetrievePetResponseModel>(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [Category("Smoke")]
        [Description("Verifies that GET retrieve a pet to (v2/pet/{petId}) returns 200, indicating a successful operation\"")]
        public async Task VerifyGetRetrievePetByIdReturns200()
        {
            // Arrange
            var request = RequestFactory.Create(Method.Get, Paths.PetController + "1");

            // Act
            var response = await ApiService.ExecuteAsync<GetRetrievePetResponseModel>(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
