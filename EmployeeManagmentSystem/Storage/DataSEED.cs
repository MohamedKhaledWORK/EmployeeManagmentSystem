using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Storage
{
    public static class DataSEED
    {
        public static void SeedData()
        {
            var employeeStorage = new SystemStorage<Employee>("employees.json");
            var departmentStorage = new SystemStorage<Department>("departments.json");

            if (!departmentStorage.Load().Any())
            {
                var departments = new List<Department>
                {
                    new Department { Id = 1, Name = "IT" },
                    new Department { Id = 2, Name = "HR" },
                    new Department { Id = 3, Name = "Finance" }

                };
                departmentStorage.Save(departments);
            }
            if (!employeeStorage.Load().Any())
            {
                var departments = departmentStorage.Load().ToList();
                var employees = new List<Employee> {
                   new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    JobTitle = "Software Engineer",
                    Email = "eddfdsf@yahoo.com",
                    MonthlySalary = 60000
                    ,Department = departments[0]
                    ,HireDate = new DateOnly(2020, 1, 15),
                    EmploymentStatus = EmployeeStatus.Active
                },
               new Employee
                {
                    Id = 2,
                    Name = "Jane Smith",
                    JobTitle = "Project Manager",
                    MonthlySalary = 75000,
                   Department = departments[1]
                    ,HireDate = new DateOnly(2020, 1, 15),
                    EmploymentStatus = EmployeeStatus.Active
                } };
                employeeStorage.Save(employees);
            }
        }
    }
}
