using Microsoft.AspNetCore.Mvc;
using Webb_Labb2.DAL.Models;

namespace Webb_Labb2.DAL
{
    public class CourseStorage
    {
        private readonly Labb2Context _labb2Context;

        public CourseStorage(Labb2Context labb2Context)
        {
            _labb2Context = labb2Context;
        }

        public bool CreateCourse(Course course)
        {
            if (_labb2Context.Courses.Contains(course))
            {
                return false;
            }
            _labb2Context.Courses.Add(course);
            return true;
        }

        public ICollection<Course> GetAllCourses()
        {
            return _labb2Context.Courses.ToList();
        }

        public Course? GetCourse(int courseNumber)
        {
            return _labb2Context.Courses.FirstOrDefault(c => c.CourseNumber == courseNumber);
        }

        public bool UpdateCourse(int courseNumber ,Course course)
        {
            var existingCourse = _labb2Context.Courses.FirstOrDefault(c => c.CourseNumber == courseNumber);
            if (existingCourse is null)
            {
                return false;
            }
            existingCourse = course;
            return true;
        }

        public bool DeleteCourse(int courseNumber)
        {
            var existingCourse = _labb2Context.Courses.FirstOrDefault(c => c.CourseNumber == courseNumber);
            if (existingCourse is null)
            {
                return false;
            }

            _labb2Context.Courses.Remove(existingCourse);
            return true;
        }
    }
}
