using EmployeeManagementSystem.Exceptions;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Storage
{
    public class StorageResolver
    {
        private readonly Dictionary<Type, string> _map = new();
        public StorageResolver Register<T>(string fileName) where T : BaseClass 
        {
            _map[typeof(T)] = fileName;
            return this;
        }

        public string Resolve<T>() where T : BaseClass
        {
            if(_map.TryGetValue(typeof(T), out var fileName))
            {
                return fileName;
            }
            throw new TypeNotFoundException(typeof(T).Name,$"No file registered");

        }
    }
}
