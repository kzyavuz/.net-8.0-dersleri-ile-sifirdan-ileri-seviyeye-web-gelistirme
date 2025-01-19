using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Registration> Registrations => Set<Registration>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
    }
}