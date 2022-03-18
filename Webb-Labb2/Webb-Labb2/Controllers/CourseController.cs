﻿using Microsoft.AspNetCore.Http;
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
            return courses.Count > 0 ? Ok(courses) : NotFound(courses);
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
            var temp = _courseStorage.CreateCourse(course);
            return Ok(temp);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Course course)
        {
            _courseStorage.UpdateCourse(id, course);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseStorage.DeleteCourse(id);
            return Ok();
        }
    }
}
