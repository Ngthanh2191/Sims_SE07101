using Microsoft.EntityFrameworkCore;
using WebSIMS.BDContext.Entities;

namespace WebSIMS.BDContext
{
    public class SIMSDBContext : DbContext
    {
        public SIMSDBContext(DbContextOptions<SIMSDBContext> options) : base(options) { }

        public DbSet<Courses> CoursesDb { get; set; }
        public DbSet<Users> UsersDb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // tale Users
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Users>().HasKey("UserID");
            modelBuilder.Entity<Users>().HasIndex("Username").IsUnique();
            modelBuilder.Entity<Users>().Property("Role").HasDefaultValue("Student");

            // table Courses
            modelBuilder.Entity<Courses>().ToTable("Courses");
            modelBuilder.Entity<Courses>().HasKey("CourseID");
            modelBuilder.Entity<Courses>().HasIndex("CourseCode").IsUnique();
        }
    }
}
