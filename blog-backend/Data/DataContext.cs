using blog_backend.Entity;
using Microsoft.EntityFrameworkCore;

namespace blog_backend.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
