using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Storage
{
    public static class StorageBootstrap
    {
        private static StorageResolver? _Resolver;

        public static StorageResolver CreateDefault()
        {
            if (_Resolver == null)
            {
                _Resolver = new StorageResolver();
                _Resolver.Register<Employee>("employees.json");
                _Resolver.Register<Department>("departments.json");
            }
            return _Resolver;

        }
    }
}
