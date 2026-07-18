using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.UI
{
    public static class SystemMenus
    {
        public static void PrintOperationMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== Employee Management System =====");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Update Employee");
            Console.WriteLine("3. Remove Employee");
            Console.WriteLine("4. Searching for Employees");
            Console.WriteLine("5. List All Employees");
            Console.WriteLine("6. Exit");
        }

        public static int SearchMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== Searching Options =====");
            Console.WriteLine("1. Search By Id");
            Console.WriteLine("2. Search By Name");
            Console.WriteLine("3. Search By Department");
            Console.WriteLine("4. Search By Status");
            Console.WriteLine("5. Back");
            int choice;
            bool ok;
            do
            {
                Console.Write("Choose a type: ");
                ok = int.TryParse(Console.ReadLine(), out choice);
            } while (!ok || choice < 1 || choice > 5);

            return choice;
        }


    }
}
