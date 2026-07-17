using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Exceptions
{
    public class DepartmentNotFoundException  : Exception
    {
        public string Name { get; set; }
        public DepartmentNotFoundException(string Name,string Message): base(Message)
        {
            this.Name = Name;
        }
    }
}
