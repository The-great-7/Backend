namespace LSS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .HasIndex(n => n.Name)
                .IsUnique();

            builder
                .HasMany(c => c.Students)
                .WithOne(s => s.Course)
                .HasForeignKey(c => c.CourseId);

            builder
                .HasMany(c => c.Assignments)
                .WithOne(a => a.Course)
                .HasForeignKey(c => c.CourseId);
        }
    }
}