using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoCrud.Api.DTO;
using TodoCrud.Api.Models;

namespace TodoCrud.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Todo, TodoDTO>().ReverseMap();
        }
    }
}
