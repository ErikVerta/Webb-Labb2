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

        public User? GetUser(string email)
        {
            return _labb2Context.Users.FirstOrDefault(u => u.Email == email);
        }

        public bool UpdateUser(int id, User user)
        {
            var existingUser = _labb2Context.Users.FirstOrDefault(u => u.Id == id);
            if (existingUser is null)
            {
                return false;
            }

            existingUser = user;
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
