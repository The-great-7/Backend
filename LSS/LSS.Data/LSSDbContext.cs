namespace LSS.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using LSS.Data.Configurations;

    public class LSSDbContext : DbContext
    {
        public LSSDbContext()
        {}

        public LSSDbContext(DbContextOptions<LSSDbContext> options)
            : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Configuration.ServerAddress);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AssignmentConfiguration());
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new StudentAssignmentConfiguration());
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new StudentCourseConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(builder);
        }
    }
}