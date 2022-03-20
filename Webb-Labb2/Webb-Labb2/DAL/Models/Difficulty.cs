namespace Webb_Labb2.DAL.Models
{
    public record Difficulty
    {
        public string Title { get; set; }

        

        public Difficulty(string title)
        {
            Title = title;
        }
    }
}
