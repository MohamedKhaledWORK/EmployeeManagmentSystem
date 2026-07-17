using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
//-Employee ID(unique)
//-Full Name notnull
//-Email Address?
//-Department relation 
//-Job Title notnull
//-Hire Date notnull
//-Monthly Salary  decimal
//-Employment Status(Active, Suspended, Resigned)  Enum
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public Department Department { get; set; }
        public string JobTitle { get; set; }
        public DateOnly HireDate { get; set; }
        public decimal MonthlySalary { get; set; }
        public EmployeeStatus EmploymentStatus { get; set; }
        public override string ToString()
        {
           return $"Employee ID: {Id}, Name: {Name}, Email: {Email}, Department: {Department?.Name}, Job Title: {JobTitle}, Hire Date: {HireDate}, Monthly Salary: {MonthlySalary:C}, Employment Status: {EmploymentStatus}";
        }
    }
}
