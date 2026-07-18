using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository;
using EmployeeManagementSystem.Services;
using EmployeeManagementSystem.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.UI
{
    public class SystemFlow
    {
        public static StorageResolver resolver = StorageBootstrap.CreateDefault();
        public static void Run() 
        {
            var EmployeeRepo = new GenericRepository<Employee>(resolver);
            var DepartmentRepo = new GenericRepository<Department>(resolver);
            bool flag;
            int operationChoice;
            while (true)
            {
                SystemMenus.PrintOperationMenu();
                do
                {
                    Console.Write("Choose an option: ");
                    flag = int.TryParse(Console.ReadLine(), out operationChoice);
                } while (!flag || operationChoice < 1 || operationChoice > 6);

                if (operationChoice == 6)
                {
                    Console.WriteLine("Exiting the system. Goodbye!");
                    break;
                }
                GenericServices.HandleOperation(operationChoice, EmployeeRepo, AddEmployee);

            }
        }




        private static Employee AddEmployee() 
        {
            var DepartmentRepo = new GenericRepository<Department>(resolver);
            string name = ReadNonEmpty("Enter Employee Name: ");
            string email = ReadNonEmpty("Enter Employee Email: ");
            int departmentId = ReadInt("Enter Department Id: ");
            var department = DepartmentRepo.GetById(departmentId);
            string jobTile= ReadNonEmpty("Enter Job Title: ");
            decimal salary = ReadInt("Enter Salary: "); 
            int hiredate = ReadInt("Enter Hire Date (YYYYMMDD): ");
            string status = ReadNonEmpty("Enter Status (Active/Inactive): ");
            var lastEmployee = new GenericRepository<Employee>(resolver).GetAll().OrderByDescending(e => e.Id).FirstOrDefault();
            if (lastEmployee == null)
            {
                lastEmployee = new Employee { Id = 0 }; // If no employees exist, start with Id 1
            }
            return new Employee
            {
                Id = lastEmployee.Id + 1,
                Department = department,
                Name = name,
                Email = email,
                JobTitle = jobTile,
                MonthlySalary = salary,
                HireDate = DateOnly.FromDateTime(DateTime.ParseExact(hiredate.ToString(), "yyyyMMdd", null)),
                EmploymentStatus = status.Equals("Active", StringComparison.OrdinalIgnoreCase) ? EmployeeStatus.Active : EmployeeStatus.Inactive
            };
        }

        #region Input Helpers

        public static int ReadInt(string prompt)
        {
            int value;
            bool ok;
            do
            {
                Console.Write(prompt);
                ok = int.TryParse(Console.ReadLine(), out value);
            } while (!ok);

            return value;
        }

        public static string ReadNonEmpty(string prompt)
        {
            string value;
            do
            {
                Console.Write(prompt);
                value = Console.ReadLine()?.Trim() ?? string.Empty;
            } while (string.IsNullOrEmpty(value));
            return value;
        } 
        #endregion


    }
}
