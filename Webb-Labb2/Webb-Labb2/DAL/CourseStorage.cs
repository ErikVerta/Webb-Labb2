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
            var courses = _courses.Values;
            return courses;
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

        public bool UpdateCourse(int id ,Course course)
        {
            if (!_courses.Keys.Contains(id))
            {
                return false;
            }

            _courses[id] = course;

            return true;
        }

        public bool DeleteCourse(int id)
        {
            if (!_courses.Keys.Contains(id))
            {
                return false;
            }

            _courses.Remove(id);

            return true;
        }
    }
}
