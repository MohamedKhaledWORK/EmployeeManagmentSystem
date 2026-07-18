using EmployeeManagementSystem.Exceptions;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseClass
    {
        private readonly SystemStorage<T> _storage;

        public GenericRepository(StorageResolver resolver)
        {
            var fileName = resolver.Resolve<T>();
            _storage = new SystemStorage<T>(fileName);
        }
        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException();
            var Entites = _storage.Load().ToList();
            Entites.Add(entity);
            _storage.Save(Entites);
        }

        public void Delete(T entity)
        {
            var Entites = _storage.Load().ToList();
            var entit = Entites.FirstOrDefault(x=> x.Id == entity.Id);
            if (entit != null)
            {
                Entites.Remove(entit);
                _storage.Save(Entites);
            }
            else 
            { 
               throw new ArgumentNullException(); 
            }
        }

        public IEnumerable<T> FindWhere(Func<T, bool> predicate)
        {
           return _storage.Load().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
           return _storage.Load();
        }

        public T GetById(int id)
        {
           return _storage.Load().FirstOrDefault(x=> x.Id == id);
        }

        public void Update(T entity)
        {
            var Entities = _storage.Load().ToList();
            var index = Entities.FindIndex(x => x.Id == entity.Id);
            if (index == -1)
                throw new InvalidOperationException($"{typeof(T).Name} with Id {entity.Id} not found.");
            Entities[index] = entity;
            _storage.Save(Entities);
        }
    }
}
