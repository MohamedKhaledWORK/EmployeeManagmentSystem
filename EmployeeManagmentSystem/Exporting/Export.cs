using EmployeeManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Exporting
{
    public class Exporter<T>
    {
        private IExportStrategy<T> _strategy = new JsonExportStrategy<T>();

        public void SetStrategy(IExportStrategy<T> strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public void Export(List<T> data, string filePath = null)
        {
            if (data == null || data.Count == 0)
            {
                Console.WriteLine("No data to export.");
                return;
            }

            string path = filePath ?? $"export_{typeof(T).Name}_{DateTime.Now:yyyyMMdd_HHmmss}.{_strategy.FormatName.ToLower()}";
            _strategy.Export(data, path);
        }
    }
}
