using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Exceptions
{
    public class TypeNotFoundException : Exception
    {
        public string Name { get; set; }
        public TypeNotFoundException(string Name,string Message):base(Message)
        {
            this.Name = Name;
        }
    }
}
