using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IExportStrategy<T>
    {
        string FormatName { get; }
        void Export(List<T> data, string filePath);
    }
}
