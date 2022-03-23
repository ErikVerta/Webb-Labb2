namespace Webb_Labb2.DAL.Models
{
    public record Difficulty
    {
        public int Id { get; set; }
        public string Title { get; set; }

        

        public Difficulty(string title)
        {
            Title = title;
        }
    }
}
