using Microsoft.EntityFrameworkCore;

namespace blog_backend.Data
{
    public class SqlRepository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        public SqlRepository(DataContext context) 
        {
            this._context = context;
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync() ;
        }
        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public async Task Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
