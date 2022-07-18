using Microsoft.EntityFrameworkCore;
using sopifyDemo.Models;

namespace sopifyDemo.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Products> items{ get; set; }
       
    }
}
