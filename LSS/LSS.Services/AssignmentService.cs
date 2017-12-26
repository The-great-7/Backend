namespace LSS.Services
{
    using System;
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

        public Assignment[] GetAssignments()
        {
            var assignments = context.Assignments.AsNoTracking().ToArray();

            return assignments;
        }

        public Assignment AddAssignment(AssignmentDto assignmentDto)
        {
            var assignment = Mapper.Map<Assignment>(assignmentDto);

            if (context.Assignments.Any(a => a.Name == assignment.Name))
            {
                throw new InvalidOperationException("An Assignment with the same name already exists.");
            }

            context.Assignments.Add(assignment);

            return assignment;
        }

        public Assignment[] ReplaceAssignments(AssignmentDto[] assignmentsDtos)
        {
            DeleteAssignments();

            var assignments = Mapper.Map<Assignment[]>(assignmentsDtos);

            context.Assignments.AddRange(assignments);

            context.SaveChanges();

            return context.Assignments.AsNoTracking().ToArray();
        }

        public Assignment ReplaceAssignment(int id, AssignmentDto assignmentDto)
        {
            var assignment = context.Assignments.Find(id);

            ValidateAssignment(assignment);

            assignment.DueDate = assignmentDto.DueDate;
            assignment.Name = assignment.Name;

            context.SaveChanges();

            return assignment;
        }
        
        public void DeleteAssignment(int id)
        {
            var assignment = context.Assignments.Find(id);

            ValidateAssignment(assignment);

            context.Remove(assignment);

            context.SaveChanges();
        }

        public void DeleteAssignments()
        {
            context.Assignments.Delete();
            context.SaveChanges();
        }

        private static void ValidateAssignment(Assignment assignment)
        {
            if (assignment == null)
            {
                throw new ArgumentException("An assignment with the given Id does not exist");
            }
        }
    }
}