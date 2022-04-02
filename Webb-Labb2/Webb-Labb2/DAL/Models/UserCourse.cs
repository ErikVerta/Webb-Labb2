namespace Webb_Labb2.DAL.Models
{
    public record UserCourse
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public int CourseNumber { get; set; }
        public Course? Course { get; set; }
    }
}
