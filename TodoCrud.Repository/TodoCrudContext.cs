using Microsoft.EntityFrameworkCore;
using TodoCrud.Domain;

namespace TodoCrud.Respository
{
    public class TodoCrudContext : DbContext
    {
        public TodoCrudContext(DbContextOptions<TodoCrudContext> options) : base(options) { }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users{ get; set; }
    }
}
