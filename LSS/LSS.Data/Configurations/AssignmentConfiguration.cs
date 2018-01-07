namespace LSS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using System;

    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasMaxLength(70)
                .IsRequired(true);

            builder.HasOne(c => c.Course)
                .WithMany(a => a.Assignments)
                .HasForeignKey(c => c.CourseId);

            builder.Property(a => a.DueDate)
                .HasDefaultValue(DateTime.Now.AddDays(7))
                .IsRequired();

            builder.HasIndex(a => a.Name).IsUnique();
        }
    }
}