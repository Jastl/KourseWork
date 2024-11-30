using System.Text.Json;

namespace FileManagmant
{
    public class FileManager<T> where T : class
    {
        private readonly string _filePath;

        public FileManager(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveData(List<T> data)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IncludeFields = true;
            var json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(_filePath, json);
        }

        public List<T> LoadData()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IncludeFields = true;
            if (!File.Exists(_filePath)) return new List<T>();
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}