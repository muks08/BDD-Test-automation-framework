using NUnit.Framework;
using RestSharp;
using Services.API;
using Services.API.Models.Response;
using System.Net;

namespace Tests.API.Controllers
{
    public class PetControllerTests : TestBase
    {
        public PetControllerTests() { }

        [Test]
        [Category("Smoke")]
        [Description("Verifies that ")]
        public async Task VerifyGetPetByIdReturns200()
        {
            // Arrange
            var request = RequestFactory.Create(Method.Get, Paths.PetController + "1");

            // Act
            var response = await ApiService.ExecuteAsync<GetPetByIdResponseModel>(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }
    }
}
