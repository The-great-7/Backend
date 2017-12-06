namespace LSS.Services
{
    using System.Linq;
    using AutoMapper;
    using LSS.Data;
    using LSS.Data.Models;
    using LSS.DataModels;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using Z.EntityFramework.Plus;

    public class AssignmentService : IAssignmentService
    {
        private readonly LSSDbContext context;

        public AssignmentService(LSSDbContext context)
        {
            this.context = context;
        }

        public Assignment AssignmentById(int id)
        {
            var assignment = context.Assignments.Find(id);

            return assignment;
        }

        public Assignment[] GetAssignment()
        {
            var assignments = context.Assignments.AsNoTracking().ToArray();

            return assignments;
        }

        public Assignment AddAssignment(AssignmentDto assignmentDto)
        {
            var assignment = Mapper.Map<Assignment>(assignmentDto);

            context.Assignments.Add(assignment);

            return assignment;
        }

        public Assignment[] ReplaceAssignments(AssignmentDto[] assignmentsDtos)
        {
            context.Assignments.Delete();

            var assignments = Mapper.Map<Assignment[]>(assignmentsDtos);

            context.Assignments.AddRange(assignments);

            context.SaveChanges();

            return assignments;
        }

        public Assignment ReplaceAssignment(int id, AssignmentDto assignmentDto)
        {
            var assignment = context.Assignments.Find(id);

            assignment.DueDate = assignmentDto.DueDate;
            assignment.Name = assignment.Name;

            context.SaveChanges();

            return assignment;
        }

        public void DeleteAssignment(int id)
        {
            var assignment = context.Assignments.Find(id);

            context.Remove(assignment);

            context.SaveChanges();
        }

        public void DeleteAssignments()
        {
            context.Assignments.Delete();
            context.SaveChanges();
        }
    }
}