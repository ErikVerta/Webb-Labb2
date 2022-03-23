using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webb_Labb2.DAL;
using Webb_Labb2.DAL.Models;

namespace Webb_Labb2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCourseController : ControllerBase
    {
        private readonly UserCourseStorage _userCourseStorage;

        public UserCourseController([FromServices] UserCourseStorage userCourseStorage)
        {
            _userCourseStorage = userCourseStorage;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userCourses = _userCourseStorage.GetAllUserCourses();
            return userCourses.Count > 0 ? Ok(userCourses) : NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usersCourses = _userCourseStorage.GetUsersCourses(id);
            return usersCourses is not null ? Ok(usersCourses) : NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserCourse userCourse)
        {
            _userCourseStorage.CreateUserCourse(userCourse);
            return Ok();
        }

        [HttpPut("{courseNumber}/{id}")]
        public IActionResult Put(int id, int courseNumber, [FromBody] UserCourse userCourse)
        {
            _userCourseStorage.UpdateUserCourse(id, courseNumber, userCourse);
            return Ok();
        }

        [HttpDelete("{courseNumber}/{id}")]
        public IActionResult Delete(int id, int courseNumber)
        {
            _userCourseStorage.DeleteUserCourse(id, courseNumber);
            return Ok();
        }
    }
}
