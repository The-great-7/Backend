namespace Project.Data.EntityConfiguration
{
    using System;
    using Project.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            builder.Property(f => f.FirstName)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(m => m.MiddleName)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(l => l.LastName)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(a => a.Address)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(p => p.PhoneNumber)
                .HasColumnType("VARCHAR(10)")
                .IsRequired(false);
        }
    }
}