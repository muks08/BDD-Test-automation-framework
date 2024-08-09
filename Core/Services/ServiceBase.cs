using NLog;
using NLog.Config;
using RestSharp;
using System.Diagnostics;

namespace Core.Services
{
    public abstract class ServiceBase
    {
        protected RestClient Client { get; }
        protected readonly Stopwatch Sw;
        private static readonly ILogger Logger;

        static ServiceBase()
        {
            LogManager.Configuration = new XmlLoggingConfiguration("Config/NLog.config");
            Logger = LogManager.GetCurrentClassLogger();
        }

        public ServiceBase(string? baseUrl)
        {
            _ = baseUrl ?? throw new ArgumentException("Url cannot be blank!");
            Client = new RestClient(baseUrl);
            Sw = new Stopwatch();
        }

        protected RestResponse<T> DeserializeResponse<T>(RestResponse response)
        {
            RestResponse<T>? deserialized = default;
            try
            {
                deserialized = Client.Deserialize<T>(response);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to deserialize response into type {typeof(T).Name}.", ex);
            }

            return deserialized!;
        }

        public async Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            Sw.Start();
            try
            {
                var response = await Client.ExecuteAsync(request);
                Sw.Stop();
                Logger.Info($"Request took: {Sw.ElapsedMilliseconds} milliseconds");

                return response;
            }
            catch (Exception ex)
            {
                Sw.Stop();
                Logger.Info($"Request took: {Sw.ElapsedMilliseconds} milliseconds");
                Logger.Error(ex, $"{GetType().Name} failed to make HTTP request. Exception message: {ex.Message}");
                throw new HttpRequestException($"{GetType().Name} failed to make HTTP request. Exception message: {ex.Message}", ex);
            }
            finally
            {
                Sw.Reset();
            }
        }

        public async Task<RestResponse<T>> ExecuteAsync<T>(RestRequest request)
        {
            Sw.Start();
            try
            {
                var response = await Client.ExecuteAsync(request);
                var model = DeserializeResponse<T>(response);
                Sw.Stop();
                Logger.Info($"Request took: {Sw.ElapsedMilliseconds}  milliseconds");

                return model;
            }
            catch (Exception ex)
            {
                Sw.Stop();
                Logger.Info($"Request took: {Sw.ElapsedMilliseconds}  milliseconds");
                Logger.Error(ex, $"{GetType().Name} failed to make HTTP request. Exception message: {ex.Message}");
                throw new HttpRequestException($"{GetType().Name} failed to make HTTP request. Exception message: {ex.Message}", ex);
            }
            finally
            {
                Sw.Reset();
            }
        }
    }
}
