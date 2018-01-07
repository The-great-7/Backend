namespace LSS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.FirstName)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(s => s.MiddleName)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(s => s.LastName)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(s => s.Address)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(s => s.PhoneNumber)
                .HasColumnType("VARCHAR(10)")
                .IsRequired(false);

            builder.Property(s => s.Grade)
                .IsRequired(false);

            builder.HasIndex(s => new {s.FirstName, s.MiddleName, s.LastName});
        }
    }
}