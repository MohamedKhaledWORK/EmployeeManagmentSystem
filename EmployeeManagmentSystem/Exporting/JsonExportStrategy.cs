using EmployeeManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Exporting
{
    public class JsonExportStrategy<T> : IExportStrategy<T>
    {
        public string FormatName => "JSON";

        public void Export(List<T> data, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"✅ Exported {data.Count} items as JSON");
        }
    }
}
