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

        [HttpGet("{courseNumber}/{id}")]
        public IActionResult Get(int courseNumber, int id)
        {
            var userCourse = _userCourseStorage.GetUserCourse(courseNumber, id);
            return userCourse is not null ? Ok(userCourse) : NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserCourse userCourse)
        {
            var result = _userCourseStorage.CreateUserCourse(userCourse);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
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
