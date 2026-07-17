using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public int Id { get; set; }
        public EmployeeNotFoundException(int Id, string message) : base(message)
        {
            this.Id = Id;
        }

    }
}
