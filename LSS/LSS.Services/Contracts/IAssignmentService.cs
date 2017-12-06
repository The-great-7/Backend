namespace LSS.Services.Contracts
{
    using LSS.DataModels;
    using LSS.Data.Models;

    public interface IAssignmentService
    {
        Assignment AssignmentById(int id);

        Assignment[] GetAssignment();

        Assignment AddAssignment(AssignmentDto assignmentDto);

        Assignment[] ReplaceAssignments(AssignmentDto[] assignments);

        Assignment ReplaceAssignment(int id, AssignmentDto assignmentDto);

        void DeleteAssignment(int id);

        void DeleteAssignments();
    }
}