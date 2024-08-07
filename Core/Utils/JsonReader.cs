using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.Utils
{
    public class JsonReader
    {
        private readonly string _directory = AppDomain.CurrentDomain.BaseDirectory;

        public JObject ReadFile(string filename)
        {
            var reader = new StreamReader(Path.Combine(_directory, filename));
            var json = reader.ReadToEnd();
            var file = JObject.Parse(json);
            return file;
        }

        public T GetFileContent<T>(string filename) where T : class
        {
            var file = ReadFile(filename);
            return file.ToObject<T>();
        }

        public T GetFileContentWithRootObjectName<T>(string filename, string rootObjectName) where T : class
        {
            var file = ReadFile(filename);
            return JsonConvert.DeserializeObject<T>(file[rootObjectName].ToString());
        }

        public string ExtractProperty(string model, string property)
        {
            var @object = JObject.Parse(model);
            return @object.SelectToken("$." + property)?.ToString();
        }

        public dynamic GetDynamicObject(string contentResponse, bool isDataContent = false)
        {
            var content = contentResponse;
            var contentObject = JsonConvert.DeserializeObject<dynamic>(content);
            if (isDataContent)
            {
                return contentObject.data;
            }
            return null;
        }
    }
}
