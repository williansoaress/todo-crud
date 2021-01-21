using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoCrud.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Password { get; set; }
        public List<Todo> Todos{ get; set; }
    }
}
