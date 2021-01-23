using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoCrud.Domain;
using TodoCrud.Repository;

namespace TodoCrud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITodoCrudRepository _repo;

        public UserController(ITodoCrudRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetUsersAsync();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados");
                throw;
            }
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> Get(int UserId)
        {
            try
            {
                var result = await _repo.GetUserAsyncById(UserId);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            try
            {
                _repo.Add(user);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/user/{user.Id}", user);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(User user)
        {
            try
            {
                var userFound = await _repo.GetUserAsyncById(user.Id);
                if (userFound == null) return NotFound();

                _repo.Update(user);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/user/{user.Id}", user);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados");
            }
            return BadRequest();
        }


    }
}
