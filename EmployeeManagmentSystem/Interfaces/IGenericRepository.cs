using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IGenericRepository
    {
        public void Add<T>(T entity);
        public void Update<T>(T entity);
        public void Delete<T>(T entity);
        public T GetById<T>(int id);
        public IQueryable<T> GetAll<T>();
    }
}
