using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IGenericRepository<T>
    {
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public T GetById(int id);
        public IQueryable<T> GetAll();
        public IQueryable<T> FindWhere(Func<T,bool> predicate);

    }
}
