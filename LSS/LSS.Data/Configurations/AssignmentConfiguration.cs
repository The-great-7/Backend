namespace LSS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {

            builder
                .HasIndex(a => a.Name)
                .IsUnique();

            builder
                .HasOne(c => c.Course)
                .WithMany(a => a.Assignments)
                .HasForeignKey(c => c.CourseId);
        }
    }
}