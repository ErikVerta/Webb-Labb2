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
            var difficulty = _labb2Context.Difficulties.FirstOrDefault(d => d.Id == course.DifficultyId);
            course.Difficulty = difficulty;
            course.UserCourses = new List<UserCourse>();
            var courseNumberExists = _labb2Context.Courses.FirstOrDefault(c => c.CourseNumber == course.CourseNumber);
            if (_labb2Context.Courses.Contains(course) || courseNumberExists is not null)
            {
                return false;
            }

            _labb2Context.Courses.Add(course);

            _labb2Context.SaveChanges();
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
            var courseNumberExists =
                _labb2Context.Courses.FirstOrDefault(c => c.CourseNumber == course.CourseNumber);
            if (existingCourse is null || courseNumberExists is not null)
            {
                return false;
            }
            var difficulty = _labb2Context.Difficulties.FirstOrDefault(d => d.Id == course.DifficultyId);
            var userCourses = _labb2Context.UserCourses.ToList();

            existingCourse.Title = course.Title;
            existingCourse.Description = course.Description;
            existingCourse.CourseNumber = course.CourseNumber;
            existingCourse.Length = course.Length;
            existingCourse.Status = course.Status;
            existingCourse.DifficultyId = course.DifficultyId;
            existingCourse.Difficulty = difficulty;
            existingCourse.UserCourses = userCourses;
            _labb2Context.SaveChanges();

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
            _labb2Context.SaveChanges();

            return true;
        }
    }
}
