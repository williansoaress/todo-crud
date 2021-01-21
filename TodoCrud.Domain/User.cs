using System.Collections.Generic;

namespace TodoCrud.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Password { get; set; }
        public List<Todo> Todos{ get; set; }
    }
}
