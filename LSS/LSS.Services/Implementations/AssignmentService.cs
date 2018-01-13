namespace LSS.Services.Implementations
{
    using AutoMapper;
    using Contracts;
    using Data;
    using Data.Models;
    using DataModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Z.EntityFramework.Plus;

    public class AssignmentService : IAssignmentService
    {
        private readonly LSSDbContext db;

        public AssignmentService(LSSDbContext db)
        {
            this.db = db;
        }

        public Assignment ById(int id)
        {
            var assignment = db.Assignments.Find(id);

            return assignment;
        }

        public IEnumerable<Assignment> All()
        {
            var assignments = this.db.Assignments.ToList();

            return assignments;
        }

        public Assignment Add(AssignmentDto assignmentDto)
        {
            var assignment = Mapper.Map<Assignment>(assignmentDto);

            if (db.Assignments.Any(a => a.Name == assignment.Name))
            {
                throw new InvalidOperationException("An Assignment with the same name already exists.");
            }

            this.db.Assignments.Add(assignment);

            return assignment;
        }

        public IEnumerable<Assignment> Replace(AssignmentDto[] assignmentsDtos)
        {
            this.DeleteAll();

            var assignments = Mapper.Map<IEnumerable<Assignment>>(assignmentsDtos);

            this.db.Assignments.AddRange(assignments);

            this.db.SaveChanges();

            return assignments;
        }

        public Assignment Replace(int id, AssignmentDto assignmentDto)
        {
            var assignment = db.Assignments.Find(id);

            ValidateAssignment(assignment);

            assignment.DueDate = assignmentDto.DueDate;
            assignment.Name = assignment.Name;

            this.db.SaveChanges();

            return assignment;
        }
        
        public void Delete(int id)
        {
            var assignment = db.Assignments.Find(id);

            ValidateAssignment(assignment);

            this.db.Remove(assignment);

            this.db.SaveChanges();
        }

        public void DeleteAll()
        {
            this.db.Assignments.Delete();
            this.db.SaveChanges();
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