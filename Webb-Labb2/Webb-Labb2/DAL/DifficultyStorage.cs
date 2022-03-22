using Webb_Labb2.DAL.Models;

namespace Webb_Labb2.DAL
{
    public class DifficultyStorage
    {
        private readonly Labb2Context _labb2Context;

        public DifficultyStorage(Labb2Context labb2Context)
        {
            _labb2Context = labb2Context;
        }

        public bool CreateDifficulty(Difficulty difficulty)
        {
            if (_labb2Context.Difficulties.Contains(difficulty))
            {
                return false;
            }

            _labb2Context.Difficulties.Add(difficulty);

            return true;
        }

        public ICollection<Difficulty> GetAllDifficulties()
        {
            return _labb2Context.Difficulties.ToList();
        }

        public Difficulty? GetDifficulty(int id)
        {
            return _labb2Context.Difficulties.FirstOrDefault(d => d.Id == id);
        }

        public bool UpdateDifficulty(int id, Difficulty difficulty)
        {
            var existingDifficulty = _labb2Context.Difficulties.FirstOrDefault(d => d.Id == id);
            if (existingDifficulty is null)
            {
                return false;
            }

            existingDifficulty = difficulty;

            return true;
        }

        public bool DeleteDifficulty(int id)
        {
            var existingDifficulty = _labb2Context.Difficulties.FirstOrDefault(d => d.Id == id);
            if (existingDifficulty is null)
            {
                return false;
            }

            _labb2Context.Difficulties.Remove(existingDifficulty);

            return true;
        }
    }
}
