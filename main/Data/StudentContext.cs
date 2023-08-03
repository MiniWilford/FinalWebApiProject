using Microsoft.EntityFrameworkCore;

namespace Main.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<Students>().HasData(
                new Students{StudentId = 1, StudentName = "Haley Beyersdoerfer", DateOfBirth = new DateTime(2001, 7, 6), StudentProgram = "Bachelors in Game Development & Design", StudentYear = 3},
                new Students{StudentId = 2, StudentName = "Kyle DeJarnett", DateOfBirth = new DateTime(2000, 6, 26), StudentProgram = "Bachelors in Information Technology", StudentYear = 2}
           );
        }

        public DbSet<Students> Student {get; set;}
    }
}
