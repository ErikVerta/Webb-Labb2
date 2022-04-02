using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webb_Labb2.DAL;
using Webb_Labb2.DAL.Models;

namespace Webb_Labb2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseStorage _courseStorage;

        public CourseController([FromServices] CourseStorage courseStorage)
        {
            _courseStorage = courseStorage;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var courses = _courseStorage.GetAllCourses();
            return courses.Count > 0 ? Ok(courses) : NotFound();
        }

        [HttpGet("{courseNumber}")]
        public IActionResult Get(int courseNumber)
        {
            var course = _courseStorage.GetCourse(courseNumber);
            return course is not null ? Ok(course) : NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            var result = _courseStorage.CreateCourse(course);
            if (result)
            {
                return Ok();
            }

            return BadRequest($"A course with coursenumber: {course.CourseNumber} already exists.");
        }

        [HttpPut("{courseNumber}")]
        public IActionResult Put(int courseNumber, [FromBody] Course course)
        {
            var result = _courseStorage.UpdateCourse(courseNumber, course);
            if (result)
            {
                return Ok();
            }

            return BadRequest($"A course with coursenumber: {course.CourseNumber} already exists.");
        }

        [HttpDelete("{courseNumber}")]
        public IActionResult Delete(int courseNumber)
        {
            var result = _courseStorage.DeleteCourse(courseNumber);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
