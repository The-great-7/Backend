namespace LSS.Services
{
    using AutoMapper;
    using Contracts;
    using Data;
    using Data.Models;
    using DataModels;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
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
            var assignments = this.context.Assignments.AsNoTracking().ToArray();

            return assignments;
        }

        public Assignment AddAssignment(AssignmentDto assignmentDto)
        {
            var assignment = Mapper.Map<Assignment>(assignmentDto);

            if (context.Assignments.Any(a => a.Name == assignment.Name))
            {
                throw new InvalidOperationException("An Assignment with the same name already exists.");
            }

            this.context.Assignments.Add(assignment);

            return assignment;
        }

        public Assignment[] ReplaceAssignments(AssignmentDto[] assignmentsDtos)
        {
            this.DeleteAssignments();

            var assignments = Mapper.Map<Assignment[]>(assignmentsDtos);

            this.context.Assignments.AddRange(assignments);

            this.context.SaveChanges();

            return context.Assignments.AsNoTracking().ToArray();
        }

        public Assignment ReplaceAssignment(int id, AssignmentDto assignmentDto)
        {
            var assignment = context.Assignments.Find(id);

            ValidateAssignment(assignment);

            assignment.DueDate = assignmentDto.DueDate;
            assignment.Name = assignment.Name;

            this.context.SaveChanges();

            return assignment;
        }
        
        public void DeleteAssignment(int id)
        {
            var assignment = context.Assignments.Find(id);

            ValidateAssignment(assignment);

            this.context.Remove(assignment);

            this.context.SaveChanges();
        }

        public void DeleteAssignments()
        {
            this.context.Assignments.Delete();
            this.context.SaveChanges();
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