namespace LearningSupportSystemData.Models.Configurations
{
    using LearningSupportSystemData.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(a => a.AssignmentId);

            builder.Property(n => n.AssignmentName)
                .HasMaxLength(70)
                .IsRequired(true);

            builder.HasOne(c => c.Course)
                .WithMany(a => a.Assignments)
                .HasForeignKey(c => c.CourseId);
        }
    }
}