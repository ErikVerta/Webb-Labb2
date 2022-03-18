using Webb_Labb2.DAL.Models;

namespace Webb_Labb2.DAL
{
    public class UserStorage
    {
        private readonly IDictionary<int, User> _users;

        private int _id;

        public UserStorage()
        {
            _users = new Dictionary<int, User>();
        }

        public bool CreateUser(User user)
        {
            if (_users.Values.Contains(user))
            {
                return false;
            }
            _users.Add(_id++, user);
            return true;
        }

        public ICollection<User> GetAllUsers()
        {
            return _users.Values;
        }

        public User? GetUser(string email)
        {
            foreach (var user in _users)
            {
                if (user.Value.Email == email)
                {
                    return user.Value;
                }
            }

            return null;
        }

        public bool UpdateUser(int id, User user)
        {
            if (!_users.Keys.Contains(id))
            {
                return false;
            }

            _users[id] = user;

            return true;
        }

        public bool DeleteUser(int id)
        {
            if (!_users.Keys.Contains(id))                                              
            {
                return false;
            }

            _users.Remove(id);

            return true;
        }
    }
}
