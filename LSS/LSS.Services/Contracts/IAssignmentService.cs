﻿namespace LSS.Services.Contracts
{
    using Data.Models;
    using DataModels;

    public interface IAssignmentService
    {
        Assignment AssignmentById(int id);

        Assignment[] GetAssignments();

        Assignment AddAssignment(AssignmentDto assignmentDto);

        Assignment[] ReplaceAssignments(AssignmentDto[] assignments);

        Assignment ReplaceAssignment(int id, AssignmentDto assignmentDto);

        void DeleteAssignment(int id);

        void DeleteAssignments();
    }
}