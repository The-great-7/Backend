namespace Project.Data
{
    using Project.Models;
    using Project.Data.EntityConfiguration;
    using Microsoft.EntityFrameworkCore;

    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext() { }

        public ProjectDbContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAssignment> StudentAssignments { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ServerAddress);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AssignmentConfiguration());
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new StudentAssignmentConfiguration());
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new StudentCourseConfiguration());
        }
    }
}