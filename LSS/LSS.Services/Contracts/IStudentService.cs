namespace LSS.Services.Contracts
{
    using Data.Models;
    using DataModels;
    using System.Collections.Generic;

    public interface IStudentService
    {
        Student StudentById(int id);

        Student[] GetStudents();

        Student AddStudent(StudentDto studentDto);

        Student[] ReplaceStudents(StudentDto[] students);

        Student ReplaceStudent(int id, StudentDto studentDto);

        ICollection<Student> DeleteStudent(int id);

        void DeleteStudents();
    }
}