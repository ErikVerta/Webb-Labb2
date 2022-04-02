using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webb_Labb2.DAL.Models
{
    public record Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Length { get; set; }
        public bool Status { get; set; }

        public int DifficultyId { get; set; }
        public Difficulty Difficulty { get; set; }

        public IList<UserCourse> UserCourses { get; set; }


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
