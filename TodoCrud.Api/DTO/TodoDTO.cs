using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoCrud.Api.DTO
{
    public class TodoDTO
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 4, ErrorMessage ="Task name must be between 4 and 50 characters.")]
        public string Name { get; set; }
        
        public string DueDate { get; set; }
        public bool IsComplete { get; set; }

        public int UserId { get; set; }
    }
}
