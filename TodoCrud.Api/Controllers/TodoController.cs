using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoCrud.Domain;
using TodoCrud.Repository;

namespace TodoCrud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoCrudRepository _repo;

        public TodoController(ITodoCrudRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetTodosAsync();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados");
                throw;
            }
        }

        [HttpGet("{TodoId}")]
        public async Task<IActionResult> Get(int TodoId)
        {
            try
            {
                var result = await _repo.GetTodosAsyncById(TodoId, false);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Todo todo)
        {
            try
            {
                _repo.Add(todo);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/todo/{todo.Id}", todo);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Bd error");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int todoId, Todo todo)
        {
            try
            {
                var oldTodo = await _repo.GetTodosAsyncById(todoId, false);
                if (oldTodo == null) return NotFound();

                _repo.Update(todo);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/todo/{todo.Id}", todo);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Bd error");
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
