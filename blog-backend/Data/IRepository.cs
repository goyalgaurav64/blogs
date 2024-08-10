using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog_backend.Data
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int id);
        Task SaveChanges();
    }
}
