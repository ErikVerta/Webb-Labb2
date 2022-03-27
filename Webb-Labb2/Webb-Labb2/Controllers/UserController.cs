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
            _userStorage.CreateUser(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            _userStorage.UpdateUser(id, user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userStorage.DeleteUser(id);
            return Ok();
        }
    }
}
