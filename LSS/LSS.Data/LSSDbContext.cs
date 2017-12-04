namespace LSS.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

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
            builder
                .Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder
                .Entity<StudentAssignment>()
                .HasKey(sa => new { sa.StudentId, sa.AssignmentId });

            builder
                .Entity<Student>()
                .HasMany(s => s.Courses)
                .WithOne(c => c.Student)
                .HasForeignKey(s => s.StudentId);

            builder
                .Entity<Student>()
                .HasMany(s => s.Assignments)
                .WithOne(a => a.Student)
                .HasForeignKey(s => s.StudentId);

           // TODO

            base.OnModelCreating(builder);
        }
    }
}