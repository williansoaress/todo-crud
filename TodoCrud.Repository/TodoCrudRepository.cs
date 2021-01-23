using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoCrud.Domain;
using TodoCrud.Respository;

namespace TodoCrud.Repository
{
    public class TodoCrudRepository : ITodoCrudRepository
    {
        private readonly TodoCrudContext _context;
        public TodoCrudRepository(TodoCrudContext context)
        {
            _context = context; 
        }

        //geral
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //todos
        public Task<Todo[]> GetTodosAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Todo> GetTodosAsyncById(int TodoId, bool includeUsers = false)
        {
            IQueryable<Todo> query = _context.Todos
                .Include(c => c.User);

            if (includeUsers)
            {
                query = query
                    .Include(tu => tu.User);
            }

            query = query.Where(t => t.Id == TodoId);
            return await query.SingleAsync();
        }

        //users
        public async Task<User> GetUserAsyncById(int UserId)
        {
            IQueryable<User> query = _context.Users
                .Include(c => c.Todos);

            query = query.OrderByDescending(u => u.Name)
                .Where(u => u.Id == UserId);

            var result = await query.FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            IQueryable<User> query = _context.Users;

            query = query.OrderByDescending(u => u.Name);

            var result = await query.ToListAsync();

            return result;
        }


    }
}
