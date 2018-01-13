namespace LSS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class StudentAssignmentConfiguration : IEntityTypeConfiguration<StudentAssignment>
    {
        public void Configure(EntityTypeBuilder<StudentAssignment> builder)
        {
            builder.
                HasKey(s => new { s.AssignmentId, s.StudentId });
            
            builder
                .HasOne(sa => sa.Student)
                .WithMany(s => s.Assignments)
                .HasForeignKey(sa => sa.StudentId);

            builder
                .HasOne(sa => sa.Assignment)
                .WithMany(s => s.Students)
                .HasForeignKey(sa => sa.AssignmentId);
        }
    }
}