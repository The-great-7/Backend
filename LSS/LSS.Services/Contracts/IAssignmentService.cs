namespace LSS.Services.Contracts
{
    using Data.Models;
    using DataModels;
    using System.Collections.Generic;

    public interface IAssignmentService
    {
        Assignment ById(int id);

        IEnumerable<Assignment> All();

        Assignment Add(AssignmentDto assignmentDto);

        IEnumerable<Assignment> Replace(AssignmentDto[] assignmentsDtos);

        Assignment Replace(int id, AssignmentDto assignmentDto);

        void Delete(int id);

        void DeleteAll();
    }
}