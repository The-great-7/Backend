namespace Project.Data.EntityConfiguration
{
    using System;
    using Project.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(s => new { s.CourseId, s.StudentId });

            builder.HasOne(c => c.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(c => c.CourseId);

            builder.HasOne(s => s.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(s => s.StudentId);
        }
    }
}