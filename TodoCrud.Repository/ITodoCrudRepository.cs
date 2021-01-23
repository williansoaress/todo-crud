using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoCrud.Domain;

namespace TodoCrud.Repository
{
    public interface ITodoCrudRepository
    {
        //geral
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //users
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsyncById(int UserId);

        //todos
        Task<Todo[]> GetTodosAsync();
        Task<Todo> GetTodosAsyncById(int TodoId, bool includeUsers);
    }
}
