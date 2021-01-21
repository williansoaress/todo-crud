using Microsoft.EntityFrameworkCore;
using TodoCrud.Api.Models;

namespace TodoCrud.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Todo> Todos { get; set; }
    }
}
