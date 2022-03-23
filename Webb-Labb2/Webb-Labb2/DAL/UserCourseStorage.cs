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
            if (_labb2Context.UserCourses.Contains(userCourse))
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

        public ICollection<UserCourse> GetUsersCourses(int id)
        {
            var usersCourses = new List<UserCourse>();
            foreach (var userCourse in _labb2Context.UserCourses)
            {
                if (userCourse.UserId == id)
                {
                    usersCourses.Add(userCourse);
                }
            }

            return usersCourses;
        }

        public bool UpdateUserCourse(int id, int courseNumber, UserCourse userCourse)
        {
            var existingUserCourse =
                _labb2Context.UserCourses.FirstOrDefault(uc => uc.UserId == id && uc.CourseNumber == courseNumber);
            if (existingUserCourse is null)
            {
                return false;
            }

            existingUserCourse = userCourse;
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
