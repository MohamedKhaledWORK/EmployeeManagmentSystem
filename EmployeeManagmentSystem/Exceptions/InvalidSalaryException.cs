using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Exceptions
{
    public class InvalidSalaryException : Exception
    {
        public decimal Salary { get; set; }
        public InvalidSalaryException(decimal Salary,string message) : base(message)
        {
            this.Salary = Salary;
        }
    }
}
