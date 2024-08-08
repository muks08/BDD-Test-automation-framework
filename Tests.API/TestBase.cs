using Core.Services.Interfaces;
using Services.API;

namespace Tests.API
{
    public class TestBase
    {
        protected ApiService ApiService { get; private set; }
        protected IHttpRequestFactoryService RequestFactory { get; }
    }
}
