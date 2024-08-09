using Core.Services.Interfaces;
using Moq;
using RestSharp;
using Services.API;

namespace Tests.API
{
    public class TestBase
    {
        protected ApiService ApiService { get; private set; }
        protected IHttpRequestFactoryService RequestFactory { get; }

        public TestBase()
        {
            var requestFactoryMock = new Mock<IHttpRequestFactoryService>();

            requestFactoryMock.Setup(x => x.Create(It.IsAny<Method>(), It.IsAny<string>()))
                .Returns((Method method, string path) => new RestRequest(path, method));

            RequestFactory = requestFactoryMock.Object;

            ApiService = new ApiService(RequestFactory);
        }
    }
}
