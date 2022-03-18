namespace Webb_Labb2.DAL.Models
{
    public record Course
    {
        public int CourseNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Length { get; set; }
        public bool Status { get; set; }
       

        public Course(int courseNumber, string title, string description, string length, bool status)
        {
            CourseNumber = courseNumber;
            Title = title;
            Description = description;
            Length = length;
            Status = status;
        }
    }
}
