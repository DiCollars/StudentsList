using Microsoft.EntityFrameworkCore;
using StudentsList.Models;

namespace StudentsList
{
    public class StudentGroupContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }

        public DbSet<Student> Students { get; set; }

        public StudentGroupContext(DbContextOptions<StudentGroupContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
