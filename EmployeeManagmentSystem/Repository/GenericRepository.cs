using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        private readonly SystemStorage<T> _storage;

        public GenericRepository(string fileName)
        {
            _storage = new SystemStorage<T>(fileName);
        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindWhere(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
