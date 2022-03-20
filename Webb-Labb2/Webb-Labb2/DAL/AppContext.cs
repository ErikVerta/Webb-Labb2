using Microsoft.EntityFrameworkCore;
using Webb_Labb2.DAL.Models;

namespace Webb_Labb2.DAL
{
    public class AppContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }

        public AppContext(DbContextOptions option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCourse>().HasKey(sc => new {sc.UserId, sc.CourseNumber});

            modelBuilder.Entity<UserCourse>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.UserCourses)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<UserCourse>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.UserCourses)
                .HasForeignKey(sc => sc.CourseNumber);
            base.OnModelCreating(modelBuilder);
        }
    }
}
