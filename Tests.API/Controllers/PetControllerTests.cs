using Core;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using Services.API;
using Services.API.Models.PetController.Response;
using Services.API.Models.PetController.Shared;
using Services.API.Payloads.PetController;
using System.Net;

namespace Tests.API.Controllers
{
    [TestOf("Swagger URL: https://petstore.swagger.io")]
    public class PetControllerTests : TestBase
    {
        public PetControllerTests() { }

        [Test]
        [Category("TestCase #")]
        [Category(TestTypes.Smoke)]
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
        [Category("TestCase #")]
        [Category(TestTypes.Smoke)]
        [Description("Verifies that GET retrieve a pet to (v2/pet/{petId}) returns 200, indicating a successful operation")]
        public async Task VerifyGetRetrievePetByIdReturns200()
        {
            // Arrange
            var request = RequestFactory.Create(Method.Get, Paths.PetController + "1");

            // Act
            var response = await ApiService.ExecuteAsync<GetRetrievePetResponseModel>(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [Category("TestCase #")]
        [Category(TestTypes.EndToEnd)]
        [Description("Verifies that the entire lifecycle of a pet (creation, retrieval, and deletion) through the API works correctly")]
        public async Task VerifyE2EPetLifecycle()
        {
            // Create a Pet
            var createPetRequest = RequestFactory.Create(Method.Post, Paths.PetController).AddJsonBody(PostCreatePetPayload.Set());
            var createPetResponse = await ApiService.ExecuteAsync<GetRetrievePetResponseModel>(createPetRequest);

            GetRetrievePetResponseModel? actualResult = createPetResponse?.Data;

            // Retrieve a Pet
            var retrievePetRequest = RequestFactory.Create(Method.Get, Paths.PetController + actualResult?.Id);
            var retrievePetResponse = await ApiService.ExecuteAsync<GetRetrievePetResponseModel>(retrievePetRequest);

            GetRetrievePetResponseModel? expectedResult = retrievePetResponse?.Data;

            // Assert
            actualResult.Id.Should().Be(expectedResult.Id);
            actualResult.Name.Should().Be(expectedResult.Name);
            actualResult.Status.Should().Be(expectedResult.Status);

            actualResult.Category.Id.Should().Be(expectedResult.Category.Id);
            actualResult.Category.Name.Should().Be(expectedResult.Category.Name);

            actualResult.PhotoUrls.First().Should().Be(expectedResult.PhotoUrls.First());
            actualResult.PhotoUrls.Last().Should().Be(expectedResult.PhotoUrls.Last());

            actualResult.Tags.First().Id.Should().Be(expectedResult.Tags.First().Id);
            actualResult.Tags.First().Name.Should().Be(expectedResult.Tags.First().Name);
            actualResult.Tags.Last().Id.Should().Be(expectedResult.Tags.Last().Id);
            actualResult.Tags.Last().Name.Should().Be(expectedResult.Tags.Last().Name);

            // Delete a Pet
            var deletePetRequest = RequestFactory.Create(Method.Delete, Paths.PetController + actualResult?.Id);
            var deletePetResponse = await ApiService.ExecuteAsync<GetRetrievePetResponseModel>(deletePetRequest);

            deletePetResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Trying to find deleted Pet
            var tryRetrievePetRequest = RequestFactory.Create(Method.Get, Paths.PetController + actualResult?.Id);
            var tryRetrievePetResponse = await ApiService.ExecuteAsync<GetRetrievePetResponseModel>(tryRetrievePetRequest);

            tryRetrievePetResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
