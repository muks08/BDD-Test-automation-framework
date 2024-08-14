using Core.Configuration;
using Core.Services;
using Core.Services.Interfaces;

namespace Services.API
{
    public class ApiService : ApiServiceBase
    {
        private readonly IHttpRequestFactoryService _requestFactory;

        public ApiService(IHttpRequestFactoryService requestFactory) : base(ConfigManager.AppSettings.BaseApiUrl)
        {
            _requestFactory = requestFactory;
        }
    }
}
