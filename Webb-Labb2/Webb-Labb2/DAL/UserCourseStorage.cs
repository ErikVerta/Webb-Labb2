using Webb_Labb2.DAL.Models;

namespace Webb_Labb2.DAL
{
    public class UserCourseStorage
    {
        private readonly Labb2Context _labb2Context;

        public UserCourseStorage(Labb2Context labb2Context)
        {
            _labb2Context = labb2Context;
        }

        public bool CreateUserCourse(UserCourse userCourse)
        {
            var user = _labb2Context.Users.FirstOrDefault(u => u.Id == userCourse.UserId);
            var course = _labb2Context.Courses.FirstOrDefault(c => c.CourseNumber == userCourse.CourseNumber);
            userCourse.User = user;
            userCourse.Course = course;

            if (_labb2Context.UserCourses.Contains(userCourse) || user is null || course is null)
            {
                return false;
            }
            _labb2Context.UserCourses.Add(userCourse);
            _labb2Context.SaveChanges();

            return true;
        }

        public ICollection<UserCourse> GetAllUserCourses()
        {
            return _labb2Context.UserCourses.ToList();
        }

        public UserCourse? GetUserCourse(int courseNumber, int id)
        {
            return _labb2Context.UserCourses.FirstOrDefault(uc => uc.UserId == id && uc.CourseNumber == courseNumber);
        }

        public bool UpdateUserCourse(int id, int courseNumber, UserCourse userCourse)
        {
            var existingUserCourse =
                _labb2Context.UserCourses.FirstOrDefault(uc => uc.UserId == id && uc.CourseNumber == courseNumber);
            if (existingUserCourse is null)
            {
                return false;
            }

            existingUserCourse.UserId = userCourse.UserId;
            existingUserCourse.CourseNumber = userCourse.CourseNumber;
            existingUserCourse.User = userCourse.User;
            existingUserCourse.Course = userCourse.Course;
            _labb2Context.SaveChanges();

            return true;
        }

        public bool DeleteUserCourse(int id, int courseNumber)
        {
            var existingUserCourse =
                _labb2Context.UserCourses.FirstOrDefault(uc => uc.UserId == id && uc.CourseNumber == courseNumber);
            if (existingUserCourse is null)
            {
                return false;
            }

            _labb2Context.UserCourses.Remove(existingUserCourse);
            _labb2Context.SaveChanges();

            return true;
        }
    }
}
