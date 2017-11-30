namespace Project.Data.EntityConfiguration
{
    using System;

    using Project.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StudentAssignmentConfiguration : IEntityTypeConfiguration<StudentAssignment>
    {
        public void Configure(EntityTypeBuilder<StudentAssignment> builder)
        {
            builder.HasKey(s => new { s.AssignmentId,s.StudentId});

            builder.Property(d => d.DueDate)
                .HasDefaultValue(DateTime.Now.AddDays(7));

            builder.HasOne(s => s.Student)
                .WithMany(s => s.StudentAssignments)
                .HasForeignKey(s => s.StudentId);

            builder.HasOne(a => a.Assignment)
                .WithMany(s => s.StudentAssignments)
                .HasForeignKey(a => a.AssignmentId);
        }
    }
}
