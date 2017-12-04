namespace LSS.Services.Contracts
{
    using LSS.Api.Dtos;
    using LSS.Data.Models;

    public interface IAssignmentService
    {
        Assignment AssignmentById(int id);

        Assignment[] GetAssignment();

        Assignment AddStudent(AssignmentDto assignmentDto);

        Assignment[] ReplaceAssignment(AssignmentDto[] assignments);

        Assignment ReplaceAssignment(int id, AssignmentDto assignmentDto);

        void DeleteAssignment(int id);

        void DeleteAssignment();
    }
}