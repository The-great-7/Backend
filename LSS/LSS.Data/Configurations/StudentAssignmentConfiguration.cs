namespace LSS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class StudentAssignmentConfiguration : IEntityTypeConfiguration<StudentAssignment>
    {
        public void Configure(EntityTypeBuilder<StudentAssignment> builder)
        {
            builder.HasKey(s => new { s.AssignmentId,s.StudentId});
            
            builder.HasOne(s => s.Student)
                .WithMany(s => s.StudentAssignments)
                .HasForeignKey(s => s.StudentId);

            builder.HasOne(a => a.Assignment)
                .WithMany(s => s.StudentAssignments)
                .HasForeignKey(a => a.AssignmentId);
        }
    }
}