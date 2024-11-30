using System.Text.Json;

namespace FileManagmant
{
    public class FileManager<T>
    {
        private readonly string _filePath;

        public FileManager(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveData(List<T> data)
        {
            if (!File.Exists(_filePath)) File.Create(_filePath);
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(_filePath, json);
        }

        public List<T> LoadData()
        {
            if (!File.Exists(_filePath)) return new List<T>();
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}