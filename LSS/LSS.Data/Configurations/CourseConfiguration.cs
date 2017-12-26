namespace LSS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(n => n.Name)
                .HasMaxLength(70)
                .IsRequired(true);

            builder.HasIndex(n => n.Name)
                .IsUnique();
        }
    }
}