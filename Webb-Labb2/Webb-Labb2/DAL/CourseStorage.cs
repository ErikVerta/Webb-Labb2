using Webb_Labb2.DAL.Models;

namespace Webb_Labb2.DAL
{
    public class CourseStorage
    {
        private readonly IDictionary<int, Course> _courses;

        private int _id;

        public CourseStorage()
        {
            _courses = new Dictionary<int, Course>();
        }

        public bool CreateCourse(Course course)
        {
            if (_courses.Values.Contains(course))
            {
                return false;
            }
            _courses.Add(_id++, course);
            return true;
        }

        public ICollection<Course> GetAllCourses()
        {
            return _courses.Values;
        }

        public Course? GetCourse(int courseNumber)
        {
            foreach (var course in _courses)
            {
                if (course.Value.CourseNumber == courseNumber)
                {
                    return course.Value;
                }
            }

            return null;
        }

        public bool UpdateCourse(int courseNumber ,Course course)
        {
            foreach (var item in _courses)
            {
                if (item.Value.CourseNumber == courseNumber)
                {
                    _courses[item.Key] = course;
                    return true;
                }
            }

            return false;
        }

        public bool DeleteCourse(int courseNumber)
        {
            foreach (var course in _courses)
            {
                if (course.Value.CourseNumber == courseNumber)
                {
                    _courses.Remove(course);
                }
            }

            return false;
        }
    }
}
