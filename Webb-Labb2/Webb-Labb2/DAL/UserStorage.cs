using Webb_Labb2.DAL.Models;

namespace Webb_Labb2.DAL
{
    public class UserStorage
    {
        private readonly Labb2Context _labb2Context;

        public UserStorage(Labb2Context labb2Context)
        {
            _labb2Context = labb2Context;
        }

        public bool CreateUser(User user)
        {
            var userCourses = _labb2Context.UserCourses.ToList();
            user.UserCourses = new List<UserCourse>();
            if (_labb2Context.Users.Contains(user))
            {
                return false;
            }

            _labb2Context.Users.Add(user);
            _labb2Context.SaveChanges();

            return true;
        }

        public ICollection<User> GetAllUsers()
        {
            return _labb2Context.Users.ToList();
        }

        public User? GetUser(int id)
        {
            return _labb2Context.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool UpdateUser(int id, User user)
        {
            var existingUser = _labb2Context.Users.FirstOrDefault(u => u.Id == id);
            if (existingUser is null)
            {
                return false;
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Address = user.Address;

            _labb2Context.SaveChanges();

            return true;
        }

        public bool DeleteUser(int id)
        {
            var existingUser = _labb2Context.Users.FirstOrDefault(u => u.Id == id);
            if (existingUser is null)
            {
                return false;
            }

            _labb2Context.Users.Remove(existingUser);
            _labb2Context.SaveChanges();

            return true;
        }
    }
}
