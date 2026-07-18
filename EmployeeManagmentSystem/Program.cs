using EmployeeManagementSystem.Storage;
using EmployeeManagementSystem.UI;

namespace EmployeeManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataSEED.SeedData();
            var resolver = StorageBootstrap.CreateDefault();
            SystemFlow.Run();
        }
    }
}
