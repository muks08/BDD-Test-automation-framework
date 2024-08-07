using Newtonsoft.Json.Linq;

namespace Core.Utils
{
    public sealed class JsonReader
    {
        private readonly string _directory = AppDomain.CurrentDomain.BaseDirectory;

        public JObject ReadFile(string filename)
        {
            var filePath = Path.Combine(_directory, filename);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File '{filename}' not found in directory '{_directory}'.");
            }

            try
            {
                using var reader = new StreamReader(filePath);
                var json = reader.ReadToEnd();
                return JObject.Parse(json);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to read or parse the file '{filename}'.", ex);
            }
        }

        public T GetFileContent<T>(string filename) where T : class
        {
            var file = ReadFile(filename);
            return file.ToObject<T>();
        }
    }
}
