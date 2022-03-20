using Webb_Labb2.DAL.Models;

namespace Webb_Labb2.DAL
{
    public class DifficultyStorage
    {
        private readonly IDictionary<int, Difficulty> _difficulties;

        private int _id;

        public DifficultyStorage()
        {
            _difficulties = new Dictionary<int, Difficulty>();
        }

        public bool CreateDifficulty(Difficulty difficulty)
        {
            if (_difficulties.Values.Contains(difficulty))
            {
                return false;
            }
            _difficulties.Add(_id++, difficulty);
            return true;
        }

        public ICollection<Difficulty> GetAllDifficulties()
        {
            return _difficulties.Values;
        }

        public Difficulty? GetDifficulty(int id)
        {
            if (!_difficulties.Keys.Contains(id))
            {
                return null;
            }

            return _difficulties[id];
        }

        public bool UpdateDifficulty(int id, Difficulty difficulty)
        {
            if (!_difficulties.Keys.Contains(id))
            {
                return false;
            }

            _difficulties[id] = difficulty;

            return true;
        }

        public bool DeleteDifficulty(int id)
        {
            if (!_difficulties.Keys.Contains(id))
            {
                return false;
            }

            _difficulties.Remove(id);

            return true;
        }
    }
}
