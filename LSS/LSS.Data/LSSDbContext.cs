namespace LSS.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using LSS.Data.Configurations;

    public class LSSDbContext : DbContext
    {
        public LSSDbContext(DbContextOptions<LSSDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

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

            base.OnModelCreating(builder);
        }
    }
}