using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Storage
{
    public  class SystemStorage<T>
    {
        private readonly string _filePath;

        public SystemStorage(string fileName)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string dataFolder = Path.Combine(basePath, "Storage");
            Directory.CreateDirectory(dataFolder);           
            _filePath = Path.Combine(dataFolder, fileName);  
        }

        public void Save(IEnumerable<T> assets)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var json = JsonSerializer.Serialize(assets, options);
            File.WriteAllText(_filePath, json);
            Console.WriteLine($"{typeof(T).Name}s saved.");
        }

        public IEnumerable<T> Load()
        {
            if (!File.Exists(_filePath))
            {
                return Enumerable.Empty<T>();
            }
            string Json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<IEnumerable<T>>(Json) ?? Enumerable.Empty<T>();
        }
    }
}
