using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.UI
{
    public static class SearchSystem
    {
        public static List<T> Searching<T>(int choice, GenericRepository<T> repo) where T : BaseClass 
        {
            switch(choice)
            {
                case 1: // Search By Id
                    int id = SystemFlow.ReadInt("Enter Id to search: ");
                    var entityById = repo.GetById(id);
                    return entityById != null ? new List<T> { entityById } : new List<T>();
                case 2: // Search By Name
                    string name = SystemFlow.ReadNonEmpty("Enter Name to search: ");
                    return repo.FindWhere(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
                case 3: // Search By Department
                    string Departname = SystemFlow.ReadNonEmpty("Enter Department to search: ");
                    List<Employee> employees = repo.GetAll().ToList() as List<Employee>;
                    var employeesInDepartment = employees.Where(e => e.Department.Name.Equals(Departname, StringComparison.OrdinalIgnoreCase)).ToList();
                    return employeesInDepartment as List<T>?? new List<T>();
                case 4: // Search By Status
                    string statusInput = SystemFlow.ReadNonEmpty("Enter Status to search (Active/Inactive): ");
                    List<Employee> Employees = repo.GetAll().ToList() as List<Employee>;
                    var employesWithStatus = Employees.Where(e => e.EmploymentStatus.ToString().ToLower() == statusInput.ToLower()).ToList();
                    return employesWithStatus as List<T> ?? new List<T>();
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            return new List<T>();
        }
    }
}
