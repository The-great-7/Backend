namespace LSS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using Models;

    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(n => n.Name)
                .HasMaxLength(70)
                .IsRequired(true);

            builder.HasOne(c => c.Course)
                .WithMany(a => a.Assignments)
                .HasForeignKey(c => c.CourseId);

            builder.Property(d => d.DueDate)
                .HasDefaultValue(DateTime.Now.AddDays(7))
                .IsRequired();
        }
    }
}