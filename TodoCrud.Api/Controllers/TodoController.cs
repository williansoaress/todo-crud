using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoCrud.Api.DTO;
using TodoCrud.Domain;
using TodoCrud.Repository;

namespace TodoCrud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITodoCrudRepository _repo;

        public TodoController(ITodoCrudRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var todos = await _repo.GetTodosAsync();
                var results = _mapper.Map<IEnumerable<TodoDTO>>(todos);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no banco de dados {ex.Message}");
                throw;
            }
        }

        [HttpGet("{TodoId}")]
        public async Task<IActionResult> Get(int TodoId)
        {
            try
            {
                var todo = await _repo.GetTodosAsyncById(TodoId, false);

                var result = _mapper.Map<TodoDTO>(todo);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(TodoDTO todoDTO)
        {
            try
            {
                var todo = _mapper.Map<Todo>(todoDTO);

                _repo.Add(todo);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/todo/{todo.Id}", _mapper.Map<TodoDTO>(todo));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Bd error {ex.Message}");
            }
            return BadRequest();
        }


        [HttpPut]
        public async Task<IActionResult> Put(int todoId, TodoDTO todoDTO)
        {
            try
            {
                var todo = await _repo.GetTodosAsyncById(todoId, false);
                if (todo == null) return NotFound();

                _mapper.Map(todoDTO, todo);

                _repo.Update(todo);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/todo/{todoDTO.Id}", _mapper.Map<TodoDTO>(todo));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Bd error {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int todoId)
        {
            try
            {
                var todo = await _repo.GetTodosAsyncById(todoId, false);
                if (todo == null) return NotFound();

                _repo.Delete(todo);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Bd error");
            }

            return BadRequest();
        }
    }
}
