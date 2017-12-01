namespace Project.Data.EntityConfiguration
{
    using Project.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder.Property(n => n.CourseName)
                .HasMaxLength(70)
                .IsRequired(true);
        }
    }
}