using RestSharp;

namespace Core.Services.Interfaces
{
    public interface IHttpRequestFactoryService
    {
        RestRequest Create(Method method, string path);
    }
}
