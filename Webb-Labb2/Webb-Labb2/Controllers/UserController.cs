using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webb_Labb2.DAL;
using Webb_Labb2.DAL.Models;

namespace Webb_Labb2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserStorage _userStorage;

        public UserController([FromServices] UserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userStorage.GetAllUsers();
            return users.Count > 0 ? Ok(users) : NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userStorage.GetUser(id);
            return user is not null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            var result = _userStorage.CreateUser(user);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            var result = _userStorage.UpdateUser(id, user);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _userStorage.DeleteUser(id);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
